using Microsoft.AspNetCore.Mvc;
using Test2.DTOs;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly IDbService _service;

    public PlayersController(IDbService service)
    {
        _service = service;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        try
        {
            var result = await _service.GetPlayerMatchesAsync(id);
            return Ok(result);
        }
        catch (ArgumentException e)
        {
            return NotFound(new { error = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayerWithMatches([FromBody] PlayerRequestDto dto)
    {
        try
        {
            await _service.AddPlayerWithMatchesAsync(dto);
            return Ok(new { message = "Player and matches added/updated." });
        }
        catch (ArgumentException e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}