

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace IncotradeBackend.Infrastructure.WebSocket
{
    [Authorize]
    public class UpdateBookingStatusNotificationHub : Hub
    {
        public async Task SendMessage(string notificationContent)
        {
            await Clients.All.SendAsync("ReceiveUpdatingBookingStatusMessage", notificationContent);
        }
    }
}