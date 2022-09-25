using Microsoft.AspNetCore.SignalR;
using tower_battle.Hubs;
using tower_battle.Models;

namespace tower_battle.Services
{
    public class GameManager : BackgroundService
    {
        private readonly IHubContext<GameHub> _hubContext;
        public GameManager(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Will be created after a room is created
            var state = new GameState();

            while (!stoppingToken.IsCancellationRequested)
            {
                state.Loop();

                await _hubContext.Clients.All.SendAsync("GameUpdated", state);

                await Task.Delay(1000);
            }
        }
    }
}
