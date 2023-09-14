using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.MovieTheater;

public class PutMovieTheaterDto
{
    [Required(ErrorMessage = "Movie theater name cannot be empty.")]
    public string Name { get; set; }
}