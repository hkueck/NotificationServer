using Avalonia;
using Avalonia.Markup.Xaml;
using NotificationSender.Contracts;
using NotificationSender.Grpc;
using NotificationSender.UseCases;
using NotificationSender.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace NotificationSender
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
            containerRegistry.RegisterSingleton<INotificationChannel, NotificationChannel>();
            containerRegistry.Register<IProductionStepsChangedUseCase, ProductionStepsChangedUseCase>();
        }

        protected override IAvaloniaObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}