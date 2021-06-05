using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<CreateGenreDTO, Genre>();

            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<CreatePersonDTO, Person>().ForMember(x => x.Picture, options => options.Ignore());
            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MoviesDTO>().ReverseMap();

            CreateMap<CreateMovieDTO, Movie>()
                .ForMember(x => x.Image, options => options.Ignore())
                .ForMember(x => x.MovieGenres, options => options.MapFrom(MapMovieGenres))
                .ForMember(x => x.MovieActors, options => options.MapFrom(MapMovieActors));

            CreateMap<Movie, MovieDetailsDTO>()
                .ForMember(x => x.Genres, options => options.MapFrom(MapMovieGenres))
                .ForMember(x => x.Actors, options => options.MapFrom(MapMovieActors));

            CreateMap<List<Movie>, IndexMoviePageDTO>().ReverseMap();

            CreateMap<Movie, MoviesPatchDTO>().ReverseMap();
        }

        private List<GenreDTO> MapMovieGenres(Movie movie,MovieDetailsDTO movieDetailsDTO)
        {
            var result = new List<GenreDTO>();
            foreach (var movieGenre in movie.MovieGenres)
            {
                result.Add(new GenreDTO() {Id=movieGenre.GenreId,Name=movieGenre.Genre.Name});
            }
            return result;
        }

        private List<ActorDTO> MapMovieActors(Movie movie, MovieDetailsDTO movieDetailsDTO)
        {
            var result = new List<ActorDTO>();
            foreach (var actor in movie.MovieActors)
            {
                result.Add(new ActorDTO() { PersonId = actor.PersonId, Order = actor.Order, Charactor = actor.Charactor,PersonName=actor.Person.Name});
            }
            return result;
        }


        private List<MovieGenres> MapMovieGenres(CreateMovieDTO createMovieDTO, Movie movie)
        {
            var result = new List<MovieGenres>();
            foreach (int id in createMovieDTO.GenreIds)
            {
                result.Add(new MovieGenres() { GenreId = id });
            }
            return result;
        }

        private List<MovieActors> MapMovieActors(CreateMovieDTO createMovieDTO, Movie movie)
        {
            var result = new List<MovieActors>();
            foreach (ActorCreationDTO actor in createMovieDTO.Actors)
            {
                result.Add(new MovieActors() { PersonId = actor.PersonId, Order = actor.Order, Charactor = actor.Charactor });
            }
            return result;
        }
    }
}
