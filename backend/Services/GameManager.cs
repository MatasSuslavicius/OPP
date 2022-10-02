using Microsoft.AspNetCore.SignalR;
using tower_battle.Hubs;
using tower_battle.Models;

namespace tower_battle.Services
{
    public class GameManager : BackgroundService
    {
        public const float UPDATE_TIME = 0.01f;

        private readonly IHubContext<GameHub> _hubContext;
        public GameManager(IHubContext<GameHub> hubContext)
        {
            _hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                GameStateSingleton.Instance.Loop();

                await _hubContext.Clients.All.SendAsync("GameUpdated", GameStateSingleton.Instance);

                await Task.Delay((int)(UPDATE_TIME * 1000f));
            }
        }
    }
}
