using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Data.DTOs.MovieTheater;

namespace MovieAPI.Data.DTOs.Section;

public class GetSectionDto
{
    public int MovieId { get; set; }
    public int MovieTheaterId { get; set; }
}