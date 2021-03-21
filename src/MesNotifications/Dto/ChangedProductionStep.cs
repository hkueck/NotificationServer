using System;

namespace MesNotifications.Dto
{
    public class ChangedProductionStep
    {
        public Guid Id { get; set; }
        public ProductionStepStatus Status { get; set; }
    }

    public enum ProductionStepStatus
    {
        None = 0,
        Active = 1,
    }
}