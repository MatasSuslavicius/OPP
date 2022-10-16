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
    
    [HttpGet("player-type")]
    public async Task<IActionResult> JoinGame([FromQuery] string connectionId)
    {
        return Ok(_gameService.GetPlayerType(connectionId));
    }
}