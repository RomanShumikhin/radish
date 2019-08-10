using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish
{
    public class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}