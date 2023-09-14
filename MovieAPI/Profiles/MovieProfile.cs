using AutoMapper;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, GetMovieDto>();
        CreateMap<PostMovieDto, Movie>();
        CreateMap<PutMovieDto, Movie>();
    }
}