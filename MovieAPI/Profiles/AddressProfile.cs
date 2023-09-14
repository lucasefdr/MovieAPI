using AutoMapper;
using MovieAPI.Data.DTOs.Address;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, GetAddressDto>();
        CreateMap<PostAddressDto, Address>();
        CreateMap<PutAddressDto, Address>();
    }
}