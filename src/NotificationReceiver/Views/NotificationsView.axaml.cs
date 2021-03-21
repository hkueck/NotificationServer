using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NotificationReceiver.Views
{
    public class NotificationsView : UserControl
    {
        public NotificationsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}