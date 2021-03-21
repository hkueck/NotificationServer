using Grpc.Net.Client;

namespace NotificationSender.Contracts
{
    public interface INotificationChannel
    {
        public GrpcChannel Channel { get; }
    }
}