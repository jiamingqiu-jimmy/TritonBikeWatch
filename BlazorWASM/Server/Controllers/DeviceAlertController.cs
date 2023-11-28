using BlazorWASM.Server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWASM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceAlertController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public DeviceAlertController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> TriggerHubMethod(string deviceName)
        {
            // Trigger the hub method for all clients
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", deviceName, $"{deviceName} has sent an Alert!");

            return Ok();
        }
    }
}
