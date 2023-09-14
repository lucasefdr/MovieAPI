using AutoMapper;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class MovieTheaterProfile : Profile
{
    public MovieTheaterProfile()
    {
        CreateMap<MovieTheater, GetMovieTheaterDto>();
        CreateMap<PostMovieTheaterDto, MovieTheater>();
        CreateMap<PutMovieDto, MovieTheater>();
    }
}