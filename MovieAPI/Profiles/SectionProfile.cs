using AutoMapper;
using MovieAPI.Data.DTOs.Section;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class SectionProfile : Profile
{
    public SectionProfile()
    {
        CreateMap<Section, GetSectionDto>();
        CreateMap<PostSectionDto, Section>();
    }
}