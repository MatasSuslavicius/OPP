using Microsoft.AspNetCore.SignalR;

namespace tower_battle.CommunicationHubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Test message");
        }
    }
}
