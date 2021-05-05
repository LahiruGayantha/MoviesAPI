﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<PeopleController> logger;
        private readonly IFilesStorageService filesStorageService;
        private readonly string containerName = "people";

        public PeopleController(ApplicationDbContext context, IMapper mapper, ILogger<PeopleController> logger, IFilesStorageService filesStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
            this.filesStorageService = filesStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> Get()
        {
            var people = await context.People.ToListAsync();
            return mapper.Map<List<PersonDTO>>(people);
        }

        [HttpGet("{id}", Name = "getPerson")]
        public async Task<ActionResult<PersonDTO>> Get(int id)
        {
            var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<PersonDTO>(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Add([FromForm] CreatePersonDTO createPerson)
        {
            var person = mapper.Map<Person>(createPerson);

            //if (createPerson.Picture != null)
            //{
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        await createPerson.Picture.CopyToAsync(memoryStream);
            //        var content = memoryStream.ToArray();
            //        var extention = Path.GetExtension(createPerson.Picture.FileName);
            //        person.Picture = await filesStorageService.SaveFile(content, extention, containerName, createPerson.Picture.ContentType);
            //    }
            //}
            context.Add(person);
            context.SaveChanges();
            var personDTO = mapper.Map<PersonDTO>(person);
            return new CreatedAtRouteResult("getPerson", new { personDTO.Id }, personDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await context.People.AnyAsync(person => person.Id == id);
            if (exists)
            {
                context.Remove(new Person() { Id = id });
                await context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NoContent();

            }

        }
    }
}
