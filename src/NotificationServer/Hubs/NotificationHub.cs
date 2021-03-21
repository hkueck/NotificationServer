using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MesNotifications.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace NotificationServer.Hubs
{
    public class NotificationHub: Hub<INotificationClient>
    {
        public static ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            if (!Connections.ContainsKey(Context.ConnectionId))
            {
                // Context.Features
                // // Connections.TryAdd(Context.QueryString["UserName"], Context.ConnectionId);
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}