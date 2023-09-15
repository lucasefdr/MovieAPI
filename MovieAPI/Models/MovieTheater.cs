using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models;

public class MovieTheater
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Movie theater name cannot be empty.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Address cannot be empty.")]
    public int AddressId { get; set; }

    public virtual Address Address { get; set; }
    public virtual ICollection<Section> Sections { get; set; }
}