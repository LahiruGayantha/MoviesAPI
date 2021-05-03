using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public interface IRepository
    {

        Genre GetGenreById(int id);
        List<Genre> GetGenres();
        void SetGenre(Genre genre);
    }
}
