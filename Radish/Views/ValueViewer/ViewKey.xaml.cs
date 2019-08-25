using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Views.ValueViewer
{
    /// <summary>
    /// The view for the keys.
    /// </summary>
    public class ViewKey : UserControl
    {
        /// <summary>
        /// The default construstor.
        /// </summary>
        public ViewKey()
        {
            DataContext = new ViewKeyViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// Initializes Component
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}