using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish.ViewModels.ConnWindow
{
    public class ConnWindow : Window
    {
        public ConnWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}