

using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace IncotradeBackend.Infrastructure.WebSocket
{
    public class SignalrUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? connection.User?.FindFirst("sub")?.Value;
        }
    }
}