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
            // Specify the time zone (Pacific Standard Time)
            TimeZoneInfo pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert UTC time to PST time
            DateTimeOffset pstNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, pstTimeZone);

            string TimedeviceName = $"{pstNow.ToString("M/d/yyyy h:mm:ss tt")} - {deviceName}";

            // Trigger the hub method for all clients
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", TimedeviceName, $"{deviceName} has sent an Alert!", true);

            return Ok();
        }
    }
}
