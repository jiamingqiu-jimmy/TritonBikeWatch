using Microsoft.AspNetCore.SignalR;

namespace BlazorWASM.Server.Hubs
{
    public class AlertHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
