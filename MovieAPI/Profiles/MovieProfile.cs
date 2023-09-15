using AutoMapper;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, GetMovieDto>()
            .ForMember(movieDto => movieDto.Sections, opt => opt.MapFrom(movie => movie.Sections));
        CreateMap<PostMovieDto, Movie>();
        CreateMap<PutMovieDto, Movie>();
    }
}