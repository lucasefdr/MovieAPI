using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Data.DTOs.Section;

namespace MovieAPI.Data.DTOs.Movie;

public class GetMovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public ICollection<GetSectionDto> Sections { get; set; }
}