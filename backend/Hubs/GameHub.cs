using Microsoft.AspNetCore.SignalR;
using tower_battle.Models;
using tower_battle.Services;

namespace tower_battle.Hubs
{
    public class GameHub : Hub
    {
        HubFacade hubFacade;
        public GameHub()
        {
            hubFacade = new HubFacade();
        }

        public async Task BuyUnit(string unitType)
        {
            hubFacade.BuyUnit(unitType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public async Task BuyTurret()
        {
            hubFacade.BuyTurret(GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public async Task BuyTurretUpgrade(string upgradeType)
        {
            hubFacade.BuyTurretUpgrade(upgradeType, GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
        public async Task SellTurret()
        {
            hubFacade.SellTurret(GameStateSingleton.Instance.Connections[Context.GetHttpContext().Request.Query["UserId"]]);
        }
    }
}
