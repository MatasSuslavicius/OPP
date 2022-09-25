using Microsoft.AspNetCore.SignalR;
using tower_battle.Hubs;
using tower_battle.Models;

namespace tower_battle.Services
{
    public class GameManager : BackgroundService
    {
        private readonly IHubContext<GameHub> _hubContext;
        public static GameState _state;
        public GameManager(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
            _state = new GameState();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _state.Loop();

                await _hubContext.Clients.All.SendAsync("GameUpdated", _state);

                await Task.Delay(1000);
            }
        }
    }
}
