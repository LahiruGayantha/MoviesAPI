using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class CreatePersonDTO
    {
        [Required(ErrorMessage = "The field with {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        [FileSizeValidator(10)]
        public IFormFile Picture { get; set; }
    }
}
