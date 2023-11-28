using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorWASM.Client
{
    public class SignalRService
    {
        HubConnection? _hubConnection;
        private readonly NavigationManager _navigationmanager;

        public event Action<string> OnItemReceived;
        
        public SignalRService(NavigationManager navigationManager)
        {
            _navigationmanager = navigationManager;
        }

        public async Task StartConnection()
        {
            if (_hubConnection is null)
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_navigationmanager.ToAbsoluteUri("/chatHub"))
                    .Build();

                _hubConnection.On<string>("ReceiveMessage", (message) =>
                {
                    OnItemReceived?.Invoke(message);
                });
            }
            await _hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
    }
}
