using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;

        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        //[ServiceFilter(typeof(MyActionFilter))]
        public ActionResult<List<Genre>> Get()
        {
            //logger.LogInformation("Getting all the genres");
            //throw new ApplicationException();
            return repository.GetGenres();
        }

        [HttpGet("{id:int}", Name = "getGenre")]
        public ActionResult<Genre> Get(int id)
        {
            var genre = repository.GetGenreById(id);
            return genre;
        }

        [HttpPost("addItems")]
        public ActionResult<Genre> Post([FromBody] Genre genre)
        {
            repository.SetGenre(genre);
            return new CreatedAtRouteResult("getGenre", new { id = genre.Id }, genre);
        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
