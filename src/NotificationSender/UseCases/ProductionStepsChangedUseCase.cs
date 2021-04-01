using System;
using MesNotificationsProto;
using NotificationSender.Contracts;

namespace NotificationSender.UseCases
{
    public class ProductionStepsChangedUseCase : IProductionStepsChangedUseCase
    {
        private static Guid _workstationId = new Guid("CF0C69F8-7F29-44D6-8143-5180A44DFB95");
        private static Guid _workstationId2 = new Guid("CF0C69F8-7F29-44D6-8143-5180A44DFB92");
        private static Guid _productionStep1Id = new Guid("EE7B6710-C676-4B0F-ADFF-1CB9B8305D0C");
        private static Guid _productionStep2Id = new Guid("0A356E84-4153-4E58-A246-DEB443401776");
        private readonly INotificationChannel _channel;

        public ProductionStepsChangedUseCase(INotificationChannel channel)
        {
            _channel = channel;
        }

        public string Execute(int workstationNumber)
        {
            var client = new NotificationServer.NotificationServerClient(_channel.Channel);
            var request = new ProductionStepsChangedRequest();
            var workstationProductionSteps = new WorkstationProductionSteps();

            if (workstationNumber == 1)
            {
                workstationProductionSteps.WorkstationId = _workstationId.ToString();
                var productionStep = new ProductionStep {Id = _productionStep1Id.ToString()};
                workstationProductionSteps.ProductionSteps.Add(productionStep);
                productionStep = new ProductionStep {Id = _productionStep2Id.ToString()};
                workstationProductionSteps.ProductionSteps.Add(productionStep);
                request.WorkstationsProductionSteps.Add(workstationProductionSteps);
            }
            else
            {
                workstationProductionSteps = new WorkstationProductionSteps();
                workstationProductionSteps.WorkstationId = _workstationId2.ToString();
                var productionStep = new ProductionStep {Id = Guid.NewGuid().ToString()};
                workstationProductionSteps.ProductionSteps.Add(productionStep);
                productionStep = new ProductionStep {Id = Guid.NewGuid().ToString()};
                workstationProductionSteps.ProductionSteps.Add(productionStep);
                request.WorkstationsProductionSteps.Add(workstationProductionSteps);
            }

            var response = client.ProductionStepsChanged(request);
            return response.Result.ToString();
        }
    }
}