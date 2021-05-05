using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The field with {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }
    }
}
