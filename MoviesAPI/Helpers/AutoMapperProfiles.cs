using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap() ;
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<CreatePersonDTO, Person>().ForMember(x=>x.Picture,options=>options.Ignore());
            CreateMap<Person, PersonPatchDTO>().ReverseMap();
            CreateMap<Movie, MoviesDTO>().ReverseMap();
            CreateMap<CreateMovieDTO, Movie>().ForMember(x => x.Image, options => options.Ignore());
        }
    }
}
