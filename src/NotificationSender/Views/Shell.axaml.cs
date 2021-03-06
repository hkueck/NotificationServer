using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NotificationSender.Views
{
    public class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}