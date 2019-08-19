using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Views.Toolbar
{
    public class TbContainer : UserControl
    {
        public TbContainer()
        {
            DataContext = new TbContainerViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}