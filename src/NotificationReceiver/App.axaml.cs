using Avalonia;
using Avalonia.Markup.Xaml;
using NotificationReceiver.Contracts;
using NotificationReceiver.ViewModels;
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
        }

        protected override IAvaloniaObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}