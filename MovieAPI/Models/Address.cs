using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models;

public class Address
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Street is required")]
    [MaxLength(60, ErrorMessage = "Street cannot be longer than 60 characters.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "City is required")]
    [MaxLength(60, ErrorMessage = "City cannot be longer than 60 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Country is required")]
    [MaxLength(60, ErrorMessage = "Country cannot be longer than 60 characters.")]
    public string Country { get; set; }
    
    public virtual MovieTheater MovieTheater { get; set;  }
}