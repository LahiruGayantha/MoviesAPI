using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class InMemoryRepository:IRepository
    {
        private List<Genre> genreList;

        public InMemoryRepository()
        {
            genreList = new List<Genre>();
            genreList.Add(new Genre() { Id = 1, Name = "Comody" });
            genreList.Add(new Genre() { Id = 2, Name = "Action" });
        }

        public List<Genre> GetGenres()
        {
            return genreList;
        }

        public Genre GetGenreById(int id)
        {
            return genreList.FirstOrDefault(element => element.Id == id);
        }

        public void SetGenre(Genre genre)
        {
            genre.Id = genreList.Max(x => x.Id) + 1;
            genreList.Add(genre);
        }

    }
}
