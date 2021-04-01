namespace NotificationSender.Contracts
{
    public interface IProductionStepsChangedUseCase
    {
        string Execute(int workstationNumber);
    }
}