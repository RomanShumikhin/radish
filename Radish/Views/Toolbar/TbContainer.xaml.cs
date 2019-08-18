using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish.Views.Toolbar
{
    public class TbContainer : UserControl
    {
        public TbContainer()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}