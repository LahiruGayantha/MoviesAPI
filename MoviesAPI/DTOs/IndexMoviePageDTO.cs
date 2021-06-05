using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.DTOs
{
    public class IndexMoviePageDTO
    {
        public List<MoviesDTO> InTheatorMovies { get; set; }
        public List<MoviesDTO> UpCommingMovies { get; set; }
    }
}
