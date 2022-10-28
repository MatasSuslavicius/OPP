using Microsoft.AspNetCore.SignalR;
using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.Hubs
{
    public class HubFacade : Hub
    {
        private readonly UnitService _unitService;
        private readonly TurretService _turretService;

        public HubFacade(UnitService unitService, TurretService turretService)
        {
            _unitService = unitService;
            _turretService = turretService;
        }

        public void BuyUnit(string unitType)
        {
            _unitService.Create(unitType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public void BuyTurret()
        {
            _turretService.Create(GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public void BuyTurretUpgrade(string upgradeType)
        {
            _turretService.Upgrade(upgradeType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public void SellTurret()
        {
            _turretService.Sell(GameStateSingleton.Instance.Connections[Context.ConnectionId]);
        }
    }
}
