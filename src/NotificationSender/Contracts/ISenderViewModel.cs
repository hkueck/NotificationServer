using System.ComponentModel;
using Prism.Commands;

namespace NotificationSender.Contracts
{
    public interface ISenderViewModel
    {
        DelegateCommand SendProductionStepChanged { get; }
        string Result { get; }
    }
}