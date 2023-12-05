using Microsoft.AspNetCore.SignalR;

namespace BlazorWASM.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, bool alert=false)
        {
            // Specify the time zone (Pacific Standard Time)
            TimeZoneInfo pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            // Get the current UTC time
            DateTime utcNow = DateTime.UtcNow;

            // Convert UTC time to PST time
            DateTimeOffset pstNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, pstTimeZone);

            user = $"{pstNow.ToString("M/d/yyyy h:mm:ss tt")} - {user}";

            await Clients.All.SendAsync("ReceiveMessage", user, message, alert);
        }
    }
}
