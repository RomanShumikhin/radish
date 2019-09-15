using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Views.StringView
{
    /// <summary>
    /// The view for the keys.
    /// </summary>
    public class StringViewer : UserControl
    {
        /// <summary>
        /// The default construstor.
        /// </summary>
        public StringViewer()
        {
            DataContext = new ViewStringKeyViewModel();
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