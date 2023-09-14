using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs.Address;

public class PutAddressDto
{
    [Required(ErrorMessage = "Street is required")]
    [StringLength(60, ErrorMessage = "Street cannot be longer than 60 characters.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "City is required")]
    [StringLength(60, ErrorMessage = "City cannot be longer than 60 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Country is required")]
    [StringLength(60, ErrorMessage = "Country cannot be longer than 60 characters.")]
    public string Country { get; set; }
}