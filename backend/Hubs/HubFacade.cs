using Microsoft.AspNetCore.SignalR;
using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.Hubs
{
    public class HubFacade
    {
        private readonly UnitService _unitService;
        private readonly TurretService _turretService;

        public HubFacade()
        {
            _unitService = new UnitService();
            _turretService = new TurretService();
        }

        public void BuyUnit(string unitType, PlayerType playerType)
        {
            _unitService.Create(unitType, playerType);
        }
        public void BuyTurret(PlayerType playerType)
        {
            _turretService.Create(playerType);
        }
        public void BuyTurretUpgrade(string upgradeType, PlayerType playerType)
        {
            _turretService.Upgrade(upgradeType, playerType);
        }
        public void SellTurret(PlayerType playerType)
        {
            _turretService.Sell(playerType);
        }
        public void BuyUnitUpgrade(string upgradeType, PlayerType playerType)
        {
            _unitService.Upgrade(upgradeType, playerType);
        }
    }
}
