using MovieAPI.Data.DTOs.Address;
using MovieAPI.Data.DTOs.Section;

namespace MovieAPI.Data.DTOs.MovieTheater;

public class GetMovieTheaterDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public GetAddressDto Address { get; set; }
    public ICollection<GetSectionDto> Sections { get; set; }
}