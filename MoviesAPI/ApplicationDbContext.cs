using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenres>().HasKey(MovieGenres => new { MovieGenres.MovieId, MovieGenres.GenreId });
            modelBuilder.Entity<MovieActors>().HasKey(MovieActors => new { MovieActors.MovieId, MovieActors.PersonId });
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var Thriller = new Genre() { Id = 1, Name = "Thriller" };
            var Horror = new Genre() { Id = 2, Name = "Horror" };
            var Crime = new Genre() { Id = 3, Name = "Crime" };
            var adventure = new Genre() { Id = 4, Name = "Adventure" };
            var animation = new Genre() { Id = 5, Name = "Animation" };
            var drama = new Genre() { Id = 6, Name = "Drama" };
            var romance = new Genre() { Id = 7, Name = "Romance" };

            modelBuilder.Entity<Genre>()
                .HasData(new List<Genre>
                {
                    adventure, animation, drama, romance,Thriller,Horror,Crime
                });

            var TomCruise = new Person() { Id = 1, Name = "Tom Cruise", DateOfBirth = new DateTime(1965, 02, 11) };
            var LarryPage = new Person() { Id = 2, Name = "Larry Page", DateOfBirth = new DateTime(1985, 03, 04) };
            var RonaldRagan = new Person() { Id = 3, Name = "Ronald Ragan", DateOfBirth = new DateTime(1981, 06, 13) };
            var VanDam = new Person() { Id = 4, Name = "Van Dam", DateOfBirth = new DateTime(1990, 06, 12) };
            var jimCarrey = new Person() { Id = 5, Name = "Jim Carrey", DateOfBirth = new DateTime(1962, 01, 17) };
            var robertDowney = new Person() { Id = 6, Name = "Robert Downey Jr.", DateOfBirth = new DateTime(1965, 4, 4) };
            var chrisEvans = new Person() { Id = 7, Name = "Chris Evans", DateOfBirth = new DateTime(1981, 06, 13) };

            modelBuilder.Entity<Person>()
                .HasData(new List<Person>
                {
                    TomCruise, LarryPage, RonaldRagan,VanDam,jimCarrey, robertDowney, chrisEvans
                });

            var endgame = new Movie()
            {
                Id = 2,
                Title = "Avengers: Endgame",
                IsShowing = true,
                ReleaseDate = new DateTime(2019, 04, 26)
            };

            var iw = new Movie()
            {
                Id = 3,
                Title = "Avengers: Infinity Wars",
                IsShowing = false,
                ReleaseDate = new DateTime(2019, 04, 26)
            };

            var sonic = new Movie()
            {
                Id = 4,
                Title = "Sonic the Hedgehog",
                IsShowing = false,
                ReleaseDate = new DateTime(2020, 02, 28)
            };
            var emma = new Movie()
            {
                Id = 5,
                Title = "Emma",
                IsShowing = false,
                ReleaseDate = new DateTime(2020, 02, 21)
            };
            var greed = new Movie()
            {
                Id = 6,
                Title = "Greed",
                IsShowing = false,
                ReleaseDate = new DateTime(2020, 02, 21)
            };
            var endgame2 = new Movie()
            {
                Id = 1,
                Title = "Avengers: X-Men",
                IsShowing = true,
                ReleaseDate = new DateTime(2019, 04, 26)
            };

            modelBuilder.Entity<Movie>()
                .HasData(new List<Movie>
                {
                    endgame2,endgame, iw, sonic, emma, greed
                });

            modelBuilder.Entity<MovieGenres>().HasData(
                new List<MovieGenres>()
                {
                     new MovieGenres(){MovieId = endgame2.Id, GenreId = drama.Id},
                    new MovieGenres(){MovieId = endgame2.Id, GenreId = adventure.Id},
                    new MovieGenres(){MovieId = endgame.Id, GenreId = drama.Id},
                    new MovieGenres(){MovieId = endgame.Id, GenreId = adventure.Id},
                    new MovieGenres(){MovieId = iw.Id, GenreId = drama.Id},
                    new MovieGenres(){MovieId = iw.Id, GenreId = adventure.Id},
                    new MovieGenres(){MovieId = sonic.Id, GenreId = adventure.Id},
                    new MovieGenres(){MovieId = emma.Id, GenreId = drama.Id},
                    new MovieGenres(){MovieId = emma.Id, GenreId = romance.Id},
                    new MovieGenres(){MovieId = greed.Id, GenreId = drama.Id},
                    new MovieGenres(){MovieId = greed.Id, GenreId = romance.Id},
                });

            modelBuilder.Entity<MovieActors>().HasData(
                new List<MovieActors>()
                {
                    new MovieActors(){MovieId = endgame2.Id, PersonId = TomCruise.Id, Charactor = "Tony Stark", Order = 1},
                    new MovieActors(){MovieId = endgame2.Id, PersonId = LarryPage.Id, Charactor = "Steve Rogers", Order = 2},
                    new MovieActors(){MovieId = endgame.Id, PersonId = robertDowney.Id, Charactor = "Tony Stark", Order = 1},
                    new MovieActors(){MovieId = endgame.Id, PersonId = chrisEvans.Id, Charactor = "Steve Rogers", Order = 2},
                    new MovieActors(){MovieId = iw.Id, PersonId = robertDowney.Id, Charactor = "Tony Stark", Order = 1},
                    new MovieActors(){MovieId = iw.Id, PersonId = chrisEvans.Id, Charactor = "Steve Rogers", Order = 2},
                    new MovieActors(){MovieId = sonic.Id, PersonId = jimCarrey.Id, Charactor = "Dr. Ivo Robotnik", Order = 1}
                });

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<MovieActors> MovieActors { get; set; }
    }
}
