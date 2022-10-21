using Microsoft.AspNetCore.SignalR;
using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.Hubs
{
    public class GameHub : Hub
    {
        private readonly UnitService _unitService;
        private readonly TurretService _turretService;
        public GameHub(UnitService unitService, TurretService turretService)
        {
            _unitService = unitService;
            _turretService = turretService;
        }
        public override Task OnConnectedAsync()
        {
            PlayerType type = PlayerType.Spectator;
            if (GameStateSingleton.Instance.Connections.Count == 0)
            {
                type = PlayerType.Left;
            }
            else if (GameStateSingleton.Instance.Connections.Count == 1)
            {
                type = PlayerType.Right;
            }
            
            GameStateSingleton.Instance.Connections.Add(Context.ConnectionId, type);
            return base.OnConnectedAsync();
        }

        public async Task BuyUnit(string unitType)
        {
            _unitService.Create(unitType, GameStateSingleton.Instance.Connections[Context.ConnectionId]);
        }
        public async Task BuyTurret()
        {
            _turretService.Create(GameStateSingleton.Instance.Connections[Context.ConnectionId]);
        }
        public async Task BuyTurretUpgrade(string upgradeType)
        {
            _turretService.Upgrade(upgradeType, GameStateSingleton.Instance.Connections[Context.ConnectionId]);
        }
    }
}
