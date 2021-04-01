using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MesNotifications.Dto;
using NotificationReceiver.Contracts;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace NotificationReceiver.ViewModels
{
    public class NotificationsViewModel : BindableBase, INotificationsViewModel
    {
        private readonly INotificationClient? _notificationClient;
        private int _workstationNumber = 1;
        private static string _workstationId = "CF0C69F8-7F29-44D6-8143-5180A44DFB95";
        private static string _workstationId2 = "CF0C69F8-7F29-44D6-8143-5180A44DFB92";

        public int WorkstationNumber
        {
            get => _workstationNumber;
            set => SetProperty(ref _workstationNumber, value); 
        }

        public DelegateCommand StartConnectionCommand { get; }

        public ObservableCollection<ProductionStepViewModel> Notifications { get; } = new ObservableCollection<ProductionStepViewModel>();

        public NotificationsViewModel()
        {
            StartConnectionCommand = new DelegateCommand(StartConnection, CanStartConnection);
        }

        public NotificationsViewModel(INotificationClient notificationClient, IEventAggregator eventAggregator): this()
        {
            _notificationClient = notificationClient;
            var changedProductionStepsEvent = eventAggregator.GetEvent<PubSubEvent<IList<ChangedProductionStep>>>();
            changedProductionStepsEvent.Subscribe(OnChangedProductionSteps, ThreadOption.UIThread);
        }

        private bool CanStartConnection()
        {
            return !_notificationClient!.Connected;
        }

        private async void StartConnection()
        {
            if (WorkstationNumber == 1)
                await _notificationClient!.Start(_workstationId);
            else
                await _notificationClient!.Start(_workstationId2);

            StartConnectionCommand.RaiseCanExecuteChanged();
        }

        private void OnChangedProductionSteps(IList<ChangedProductionStep> changedProductionSteps)
        {
            foreach (var changedProductionStep in changedProductionSteps)
            {
                var viewModel = new ProductionStepViewModel {Id = changedProductionStep.Id, State = changedProductionStep.State.ToString()};
                Notifications.Insert(0, viewModel);
            }
        }
    }
}