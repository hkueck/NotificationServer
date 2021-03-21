using System.Collections.Generic;
using System.Threading.Tasks;
using MesNotifications.Dto;

namespace MesNotifications.Contracts
{
    public interface INotificationClient
    {
        Task SendProductionStepChanged(List<ChangedProductionStep> productionSteps);
    }
}