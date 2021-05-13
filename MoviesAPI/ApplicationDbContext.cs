using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenres>().HasKey(MovieGenres => new { MovieGenres.MovieId, MovieGenres.GenreId });
            modelBuilder.Entity<MovieActors>().HasKey(MovieActors => new { MovieActors.MovieId, MovieActors.PersonId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
