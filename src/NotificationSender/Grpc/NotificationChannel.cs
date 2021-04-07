using System;
using Grpc.Net.Client;
using NotificationSender.Contracts;

namespace NotificationSender.Grpc
{
    public class NotificationChannel : INotificationChannel
    {
        private GrpcChannel _channel = null!;

        public GrpcChannel Channel
        {
            get
            {
                try
                {
                    if (_channel == null)
                    {
                        _channel = GrpcChannel.ForAddress("http://localhost:5000");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                return _channel;
            }
        }

    }
}