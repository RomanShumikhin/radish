using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.DBList
{
    /// <summary>
    /// The DB List Control.
    /// </summary>
    public class DBList : UserControl
    {
        /// <summary>
        /// The DB List constructor.
        /// </summary>
        public DBList()
        {
            this.DataContext = new DBListViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// Initializing the control.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}