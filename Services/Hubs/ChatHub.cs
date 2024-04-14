using Microsoft.AspNetCore.SignalR;


public class ChatHub : Hub
{
    public async Task SendMessage(string from, string message) => await Clients.All.SendAsync("ReceiveMessage", from, message);
    public override Task OnConnectedAsync()
    {
        Console.WriteLine(Context.ConnectionId);
        Console.WriteLine(Context.User);
        return base.OnConnectedAsync();
    }
}