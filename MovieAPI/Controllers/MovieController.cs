using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.Movie;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region HTTP methods

    [HttpGet]
    public IEnumerable GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<GetMovieDto>>(_context.Movies.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie is null) return NotFound();

        var movieDto = _mapper.Map<GetMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpPost]
    public IActionResult PostMovie([FromBody] PostMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult PutMovie(int id, [FromBody] PutMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie is null) return NotFound();

        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie is null) return NotFound();

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }

    #endregion
}