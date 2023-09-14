using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Data.DTOs.MovieTheater;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieTheaterController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region HTTP methods

    [HttpGet]
    public IEnumerable GetMovieTheaters([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<GetMovieTheaterDto>>(_context.MovieTheaters.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieTheaterById(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater is null) return NotFound();

        var movieTheaterDto = _mapper.Map<GetMovieTheaterDto>(movieTheater);

        return Ok(movieTheaterDto);
    }

    [HttpPost]
    public IActionResult PostMovieTheater([FromBody] PostMovieTheaterDto movieTheaterDto)
    {
        var movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);

        _context.MovieTheaters.Add(movieTheater);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieTheaterById), new { id = movieTheater.Id }, movieTheater);
    }

    [HttpPut("{id}")]
    public IActionResult PutMovieTheater(int id, [FromBody] PutMovieTheaterDto movieTheaterDto)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater is null) return NotFound();

        _mapper.Map(movieTheaterDto, movieTheater);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieTheater(int id)
    {
        var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);

        if (movieTheater is null) return NotFound();

        _context.MovieTheaters.Remove(movieTheater);
        _context.SaveChanges();

        return NoContent();
    }

    #endregion
}