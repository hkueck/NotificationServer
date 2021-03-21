using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MesNotifications.Contracts;
using MesNotifications.Dto;
using Microsoft.AspNetCore.SignalR.Client;

namespace NotificationReceiver.SignalR
{
    public class Client
    {
        private HubConnection _connection;

        public Client()
        {
            _connection = new HubConnectionBuilder().WithUrl("Http://localhost:5000/notifications").Build();
            _connection.Closed += async error =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
            _connection.On<IList<ChangedProductionStep>>(nameof(INotificationClient.SendProductionStepChanged), OnChangedProductionStep);
        }

        private void OnChangedProductionStep(IList<ChangedProductionStep> obj)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _connection.StartAsync();
        }
    }
}