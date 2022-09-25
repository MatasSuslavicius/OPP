using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using tower_battle.CommunicationHubs;

namespace tower_battle.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IHubContext<MessageHub> _hubContext;
        public MessageController(IHubContext<MessageHub> messageHub) { _hubContext = messageHub; }

        [HttpPost]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            await _hubContext.Clients.All.SendAsync("sendToReact", "Cool msg: " + messagePost.Message);
            return Ok();
        }
    }

    public class MessagePost
    {
        public virtual string Message { get; set; }
    }
}
