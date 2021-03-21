using System;
using NotificationReceiver.Contracts;
using Prism.Mvvm;

namespace NotificationReceiver.ViewModels
{
    public class NotificationsViewModel : BindableBase, INotificationsViewModel
    {
        private static string _workstationId = "CF0C69F8-7F29-44D6-8143-5180A44DFB95";
 
        public NotificationsViewModel()
        {
           
        }
    }
}