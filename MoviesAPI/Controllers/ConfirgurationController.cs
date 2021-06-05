using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/config")]
    public class ConfirgurationController:ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConfirgurationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            return Ok(configuration["myName"]);
        }
    }
}
