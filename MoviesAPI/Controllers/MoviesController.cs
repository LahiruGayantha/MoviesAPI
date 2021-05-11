using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public async Task<ActionResult<List<MoviesDTO>>> Get()
        {
            var allMovies = await context.Movies.AsNoTracking().ToListAsync();
            return mapper.Map<List<MoviesDTO>>(allMovies);
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
            var exists = await context.Movies.AnyAsync(movie => movie.Id == id);
            if (!exists)
            {
                return NoContent();
            }
            else
            {
                var udateDetails = mapper.Map<Movie>(createMovieDTO);
                udateDetails.Id = id;
                context.Entry(udateDetails).State = EntityState.Modified;
                await context.SaveChangesAsync();
                var updatedDetails = mapper.Map<MoviesDTO>(udateDetails);
                return updatedDetails;
            }
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
        public async Task<ActionResult> Patch(int id,[FromBody] JsonPatchDocument<MoviesPatchDTO> patchDocument)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            var patchMovieDTO = mapper.Map < MoviesPatchDTO > (movie);
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
