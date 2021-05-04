using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class CreateGenreDTO
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
