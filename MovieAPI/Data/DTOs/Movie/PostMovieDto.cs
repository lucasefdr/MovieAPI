using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.Movie;

public class PostMovieDto
{
    [Required(ErrorMessage = "Title cannot be empty.")]
    [MaxLength(60, ErrorMessage = "Title cannot be longer than 60 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Genre cannot be empty.")]
    [MaxLength(60, ErrorMessage = "Genre cannot be longer than 60 characters.")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Duration cannot be empty.")]
    [Range(0, 300, ErrorMessage = "Duration must be between 0 and 300 minutes.")]
    public int Duration { get; set; }
}