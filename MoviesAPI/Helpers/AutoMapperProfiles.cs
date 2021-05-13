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


            CreateMap<Movie, MoviesPatchDTO>().ReverseMap();
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

        private List<MovieActors> MapMovieActors(CreateMovieDTO createMovieDTO,Movie movie)
        {
            var result = new List<MovieActors>();
            foreach (ActorDTO  actor in createMovieDTO.Actors)
            {
                result.Add(new MovieActors() { PersonId = actor.PersonId, Order = actor.Order, Charactor = actor.Charactor });
            }
            return result;
        }
    }
}
