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
        private int _workstationNumber;

        public DelegateCommand SendProductionStepChanged
        {
            get;
        }

        public string Result
        {
            get => _result;
            set
            {
                SetProperty(ref _result, value);
            }
        }

        public int WorkstationNumber
        {
            get => _workstationNumber;
            set
            {
                SetProperty(ref _workstationNumber, value);
            }
        }

        public SenderViewModel()
        {
            _result = "";
            _workstationNumber = 1;
            SendProductionStepChanged = new DelegateCommand(OnSendPropertyChanged);
        }

        public SenderViewModel(IProductionStepsChangedUseCase productionStepsChangedUseCase): this()
        {
            _productionStepsChangedUseCase = productionStepsChangedUseCase;
        }

        private void OnSendPropertyChanged()
        {
            // for (int i = 0; i < 1000; i++)
            // {
                Result = _productionStepsChangedUseCase?.Execute(_workstationNumber) ?? throw new InvalidOperationException();
            // }
        }

    }
}