using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.Section;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SectionController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public SectionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable GetSections([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Sections.Skip(skip).Take(take);
    }

    [HttpGet("{movieId}/{movieTheaterId}")]
    public IActionResult GetSection(int movieId, int movieTheaterId)
    {
        var section = _context.Sections
            .FirstOrDefault(section => section.MovieId == movieId && section.MovieTheaterId == movieTheaterId);

        if (section is null) return NotFound();

        return Ok(section);
    }

    [HttpPost]
    public IActionResult PostSection([FromBody] PostSectionDto sectionDto)
    {
        var section = _mapper.Map<Section>(sectionDto);

        _context.Sections.Add(section);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetSection),
            new { movieId = section.MovieId, movieTheaterId = section.MovieTheaterId }, section);
    }
}