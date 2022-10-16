using Microsoft.AspNetCore.SignalR;
using tower_battle.Models;

namespace tower_battle.Hubs
{
    public class GameHub : Hub
    {
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
    }
}
