using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.DBList
{
    public class DBList : UserControl
    {
        public DBList()
        {
            this.DataContext = new DBListViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}