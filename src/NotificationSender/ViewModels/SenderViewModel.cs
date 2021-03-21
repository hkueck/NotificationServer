using System;
using NotificationSender.Contracts;
using Prism.Commands;
using Prism.Mvvm;

namespace NotificationSender.ViewModels
{
    public class SenderViewModel: BindableBase, ISenderViewModel
    {
        private readonly IProductionStepsChangedUseCase? _productionStepsChangedUseCase;
        private string _result;

        public DelegateCommand SendProductionStepChanged
        {
            get;
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public SenderViewModel()
        {
            _result = "";
            SendProductionStepChanged = new DelegateCommand(OnSendPropertyChanged);
        }

        public SenderViewModel(IProductionStepsChangedUseCase productionStepsChangedUseCase): this()
        {
            _productionStepsChangedUseCase = productionStepsChangedUseCase;
        }

        private void OnSendPropertyChanged()
        {
            Result = _productionStepsChangedUseCase?.Execute() ?? throw new InvalidOperationException();
        }

    }
}