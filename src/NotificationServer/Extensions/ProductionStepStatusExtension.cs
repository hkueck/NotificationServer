using System;
using MesNotifications.Dto;

namespace NotificationServer.Extensions
{
    public static class ProductionStepStatusExtention
    {
        public static ProductionStepStatus StepStatus(this MesNotificationsProto.ProductionStep productionStep)
        {
            switch (productionStep.Status)
            {
                case MesNotificationsProto.ProductionStepStatus.None:
                    return ProductionStepStatus.None;
                case MesNotificationsProto.ProductionStepStatus.Active:
                    return ProductionStepStatus.Active;
                default:
                    throw new ArgumentOutOfRangeException(nameof(productionStep), productionStep, null);
            }
        }
    }
}