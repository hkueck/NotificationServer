using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MesNotifications.Dto;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using INotificationClient = NotificationReceiver.Contracts.INotificationClient;

namespace NotificationReceiver.SignalR
{
    public class NotificationClient : INotificationClient
    {
        private HubConnection _connection = null!;
        private PubSubEvent<IList<ChangedProductionStep>> _changedProductionStepEvent;

        public bool Connected { get; private set; }

        public NotificationClient(IEventAggregator aggregator)
        {
            _changedProductionStepEvent = aggregator.GetEvent<PubSubEvent<IList<ChangedProductionStep>>>();
        }

        private void OnChangedProductionStep(IList<ChangedProductionStep> changedProductionSteps)
        {
            _changedProductionStepEvent.Publish(changedProductionSteps);
        }

        public async Task<bool> Start(string workstationId)
        {
            try
            {
                _connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:5001/mes/notifications", options =>
                    {
                        options.Headers["wid"] = $"{workstationId}";
                    })
                    .AddJsonProtocol()
                    .Build();
                _connection.On<IList<ChangedProductionStep>>(nameof(MesNotifications.Contracts.INotificationClient.SendProductionStepChanged), OnChangedProductionStep);
                _connection.Closed += ConnectionOnClosed; 
                await _connection.StartAsync();
                Connected = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return Connected;
        }

        private async Task ConnectionOnClosed(Exception arg)
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        }
    }
}
