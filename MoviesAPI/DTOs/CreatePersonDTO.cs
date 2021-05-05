using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Validations;

namespace MoviesAPI.DTOs
{
    public class CreatePersonDTO
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        [FileSizeValidator(10)]
        public IFormFile Picture { get; set; }
    }
}
