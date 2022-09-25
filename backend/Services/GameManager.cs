using Microsoft.AspNetCore.SignalR;
using tower_battle.Hubs;

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
            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubContext.Clients.All.SendAsync("GameUpdated", "This will be the new game state");

                await Task.Delay(1000);
            }
        }
    }
}
