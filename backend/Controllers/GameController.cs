using Microsoft.AspNetCore.Mvc;
using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet("PlayerType")]
    public async Task<IActionResult> PlayerType([FromQuery] string userId)
    {
        return Ok(_gameService.GetPlayerType(userId));
    }

    [HttpPost("PlayerType")]
    public async Task<IActionResult> PlayerType([FromQuery] string userId, [FromQuery]  PlayerType type)
    {
        _gameService.SetPlayerType(userId, type);
        return Ok();
    }

    [HttpPost("Join")]
    public async Task<IActionResult> Join([FromQuery] string userId)
    {
        var role = _gameService.JoinGame(userId);
        return Ok(role);
    }

    [HttpPost("Pause")]
    public async Task<IActionResult> Pause([FromQuery] bool paused)
    { 
        return Ok(_gameService.Pause(paused));
    }
}