using Avalonia;
using Avalonia.Markup.Xaml;
using NotificationReceiver.Contracts;
using NotificationReceiver.SignalR;
using NotificationReceiver.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace NotificationReceiver
{
    public class App : PrismApplication
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<INotificationClient, NotificationClient>();
        }

        protected override IAvaloniaObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}