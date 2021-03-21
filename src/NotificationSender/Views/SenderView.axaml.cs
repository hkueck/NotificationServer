using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NotificationSender.Views
{
    public class SenderView : UserControl
    {
        public SenderView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}