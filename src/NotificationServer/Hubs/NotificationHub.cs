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
                var request = Context.GetHttpContext().Request;
                var workstationId = request.Headers["wid"].ToString();
                Connections[workstationId.ToLower()] = Context.ConnectionId;
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var request = Context.GetHttpContext().Request;
            var workstationId = request.Headers["wid"];
            if (Connections.ContainsKey(workstationId))
            {
                Connections.TryRemove(workstationId, out _);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}