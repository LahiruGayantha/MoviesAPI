using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "You have missing {0} attribute")]
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        public byte[] Image { get; set; }
        [ModelBinder(BinderType =typeof(TypeBinder<List<int>>))]
        public List<int> GenreIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorCreationDTO>>))]
        public List<ActorCreationDTO> Actors { get; set; }
    }
}
