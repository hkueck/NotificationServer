using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using MesNotifications.Contracts;
using MesNotifications.Dto;
using MesNotificationsProto;
using Microsoft.AspNetCore.SignalR;
using NotificationServer.Hubs;
using NotificationServer.Extensions;

namespace NotificationServer.Services
{
    public class NotificationService: MesNotificationsProto.NotificationServer.NotificationServerBase
    {
        private readonly IHubContext<NotificationHub, INotificationClient> _hubContext;

        public NotificationService(IHubContext<NotificationHub, INotificationClient> hubContext)
        {
            _hubContext = hubContext;
        }
        
        public override Task<NotificationResponse> ProductionStepsChanged(ProductionStepsChangedRequest request, ServerCallContext context)
        {
            foreach (var workstationProductionSteps in request.WorkstationsProductionSteps)
            {
                var productionSteps = new List<ChangedProductionStep>();
                foreach (var step in workstationProductionSteps.ProductionSteps)
                {
                    var productionStep = new ChangedProductionStep {Id = new Guid(step.Id), State =  step.StepStatus()};
                    productionSteps.Add(productionStep);
                }

                if (NotificationHub.Connections.TryGetValue(workstationProductionSteps.WorkstationId.ToLower(), out var connectionId)){
                    _hubContext.Clients.Client(connectionId).SendProductionStepChanged(productionSteps);
                }
            }
            var response = new NotificationResponse{Result = NotificationResult.Success};
            return Task.FromResult(response);
        }
    }
}
