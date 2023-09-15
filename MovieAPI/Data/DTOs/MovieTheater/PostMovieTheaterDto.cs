using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.MovieTheater;

public class PostMovieTheaterDto
{
    [Required(ErrorMessage = "Movie theater name cannot be empty.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Address cannot be empty.")]
    public int AddressId { get; set; }
}