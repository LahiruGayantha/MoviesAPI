using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class MoviesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsShowing { get; set; }
        public byte[] Image { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenreIds { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorDTO>>))]
        public List<ActorDTO> Actors { get; set; }
    }
}
