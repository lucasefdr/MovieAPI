using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.DTOs.Address;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #region HTTP methods

    [HttpGet]
    public IEnumerable GetAddresses([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<GetAddressDto>>(_context.Addresses.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address is null) return NotFound();

        var addressDto = _mapper.Map<GetAddressDto>(address);

        return Ok(address);
    }

    [HttpPost]
    public IActionResult PostAddress([FromBody] PostAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);

        _context.Addresses.Add(address);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
    }

    [HttpPut("{id}")]
    public IActionResult PutAddress(int id, [FromBody] PutAddressDto addressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address is null) return NotFound();

        _mapper.Map(addressDto, addressDto);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address is null) return NotFound();

        _context.Addresses.Remove(address);
        _context.SaveChanges();

        return NoContent();
    }

    #endregion
}