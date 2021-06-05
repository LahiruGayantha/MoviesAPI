using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ILogger<MoviesController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("inTheater")]
        public async Task<ActionResult<IndexMoviePageDTO>> Get()
        {
            var inTheaters = await context.Movies
                .Where(x => x.IsShowing == true)
                .OrderBy(x => x.Id)
                .Take(2)
                .ToListAsync();

            var upcommingRelease = await context.Movies
                .Where(x => x.ReleaseDate > DateTime.Today)
                .OrderBy(x => x.Id)
                .Take(2)
                .ToListAsync();

            var result = new IndexMoviePageDTO
            {
                UpCommingMovies = mapper.Map<List<MoviesDTO>>(upcommingRelease),
                InTheatorMovies = mapper.Map<List<MoviesDTO>>(inTheaters)
            };
            return result;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<MoviesDTO>>> Filter([FromQuery] FilterMoviesDTO filterMoviesDTO)
        {
            var moviesQueryable = context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.Title))
            {
                moviesQueryable = moviesQueryable.Where(x => x.Title.Contains(filterMoviesDTO.Title));
            }

            if (filterMoviesDTO.InTheator)
            {
                moviesQueryable = moviesQueryable.Where(x => x.IsShowing);
            }

            if (filterMoviesDTO.UpCommingReleases)
            {
                moviesQueryable = moviesQueryable.Where(x => x.ReleaseDate > DateTime.Today);
            }

            if (filterMoviesDTO.GenreId != 0)
            {
                moviesQueryable = moviesQueryable.Where(x => x.MovieGenres.Select(y => y.GenreId).Contains(filterMoviesDTO.GenreId));
            }

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.OrderBy))
            {
                try
                {
                    moviesQueryable = moviesQueryable.OrderBy($"{filterMoviesDTO.OrderBy} {(filterMoviesDTO.Ascending ? "ascending" : "descending")}");
                }
                catch (Exception e)
                {
                    // throw;
                    logger.LogWarning("Error Detected", e.Message);
                }
            }

            await HttpContext.InsertPaginationParametersInResponse(moviesQueryable, filterMoviesDTO.RecordsPerPage);

            var moviesList = await moviesQueryable.Paginate(filterMoviesDTO.Pagination).ToListAsync();

            return mapper.Map<List<MoviesDTO>>(moviesList);
        }

        [HttpGet]
        public async Task<ActionResult<List<MoviesDTO>>> GetAllMovies()
        {
            var movies = await context.Movies.ToListAsync();
            return mapper.Map<List<MoviesDTO>>(movies);
        }


        [HttpGet("details/{id:int}")]
        public async Task<ActionResult<MovieDetailsDTO>> movieDetails(int id)
        {
            var movie = await context.Movies
                .Include(x => x.MovieActors).ThenInclude(x => x.Person)
                .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return mapper.Map<MovieDetailsDTO>(movie);

        }

        [HttpGet("{id:int}", Name = "getMovieById")]
        public async Task<ActionResult<MoviesDTO>> GetById(int id)
        {
            var allMovies = await context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            return mapper.Map<MoviesDTO>(allMovies);
        }

        [HttpPost]
        public async Task<ActionResult<MoviesDTO>> AddMovie([FromForm] CreateMovieDTO createMovieDTO)
        {
            var movie = mapper.Map<Movie>(createMovieDTO);
            await context.AddAsync(movie);
            await context.SaveChangesAsync();
            var movieDTO = mapper.Map<MoviesDTO>(movie);
            return new CreatedAtRouteResult("getMovieById", new { movieDTO.Id }, movieDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MoviesDTO>> UpdateFromPut(int id, [FromForm] CreateMovieDTO createMovieDTO)
        {
            var movieDB = await context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            if (movieDB == null)
            {
                return NoContent();
            }
            movieDB = mapper.Map(createMovieDTO, movieDB);
            movieDB.Id = id;
            await context.Database.ExecuteSqlInterpolatedAsync($"delete from MovieActors where MovieId={id};delete from MovieGenres where MovieId={id}");
            await context.SaveChangesAsync();
            var updatedDetails = mapper.Map<MoviesDTO>(movieDB);
            return updatedDetails;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Movies.AnyAsync(movie => movie.Id == id);
            if (exists)
            {
                context.Movies.Remove(new Movie { Id = id });
                await context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MoviesPatchDTO> patchDocument)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            var patchMovieDTO = mapper.Map<MoviesPatchDTO>(movie);
            patchDocument.ApplyTo(patchMovieDTO, ModelState);
            var isValid = TryValidateModel(patchMovieDTO);
            if (!isValid)
            {
                return BadRequest();
            }
            else
            {
                mapper.Map(patchMovieDTO, movie);
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
