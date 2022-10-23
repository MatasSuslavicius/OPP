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

        public async Task BuyUnit(string unitType)
        {
            _unitService.Create(unitType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public async Task BuyTurret()
        {
            _turretService.Create(GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public async Task BuyTurretUpgrade(string upgradeType)
        {
            _turretService.Upgrade(upgradeType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
    }
}
