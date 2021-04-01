using System;
using Prism.Mvvm;

namespace NotificationReceiver.ViewModels
{
    public class ProductionStepViewModel: BindableBase
    {
        private Guid _id;
        private string _state = "";

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                RaisePropertyChanged();
            }
        }
    }
}