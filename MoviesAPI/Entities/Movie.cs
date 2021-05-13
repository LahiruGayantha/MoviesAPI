using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You have missing {0} attribute")]
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        public byte[] Image { get; set; }
        public List<MovieGenres> MovieGenres { get; set; }
        public List<MovieActors> MovieActors { get; set; }
    }
}
