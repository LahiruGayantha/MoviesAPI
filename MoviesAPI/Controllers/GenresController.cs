using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper )
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        //[ServiceFilter(typeof(MyActionFilter))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            //logger.LogInformation("Getting all the genres");
            //throw new ApplicationException();
            var genreList =  await context.Genres.AsNoTracking().ToListAsync();
            return mapper.Map<List<GenreDTO>>(genreList);
        }

        [HttpGet("{id:int}", Name = "getGenre")]
        public ActionResult<GenreDTO> Get(int id)
        {
            var genre = context.Genres.FirstOrDefault(x => x.Id == id);
            return mapper.Map<GenreDTO>(genre);
        }

        [HttpPost("addItems")]
        public ActionResult<GenreDTO> Post([FromBody] CreateGenreDTO createGenreDTO)
        {
            var genre = mapper.Map<Genre>(createGenreDTO);
            context.Add(genre);
            context.SaveChanges();
            var genreDTO = mapper.Map<GenreDTO>(genre);
            return new CreatedAtRouteResult("getGenre", new { id = genreDTO.Id }, genreDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreDTO genreDTO)
        {
            var exists = await context.Genres.AnyAsync(x => x.Id == id);
            if (exists)
            {
                var genre = mapper.Map<Genre>(genreDTO);
                genre.Id = id;
                context.Entry(genre).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NoContent();
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var exists = await context.Genres.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound();
            }
            else
            {
                context.Remove(new Genre() { Id = id });
                await context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
