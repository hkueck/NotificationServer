using System;
using System.Threading.Tasks;

namespace NotificationReceiver.Contracts
{
    public interface INotificationClient
    {
        Task<bool> Start(string workstationId);
        bool Connected { get;  }
    }
}