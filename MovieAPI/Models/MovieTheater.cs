using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models;

public class MovieTheater
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Movie theater name cannot be empty.")]
    public string Name { get; set; }
}