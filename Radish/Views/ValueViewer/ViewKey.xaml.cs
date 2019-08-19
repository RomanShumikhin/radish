using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Views.ValueViewer
{
    public class ViewKey : UserControl
    {
        public ViewKey()
        {
            DataContext = new ViewKeyViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}