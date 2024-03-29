using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

[Authorize]
public class ChatSampleHub : Hub
{
    public override Task OnConnectedAsync() =>
        Clients.All.SendAsync("broadcastMessage", "_SYSTEM_", $"{Context.User?.Identity?.Name} JOINED");

    public Task BroadcastMessage(string message) =>
        Clients.All.SendAsync("broadcastMessage", Context.User?.Identity?.Name, message);

    public Task Echo(string message) =>
        Clients.Client(Context.ConnectionId)
            .SendAsync("echo", Context.User?.Identity?.Name, $"{message} (echo from server)");
}
