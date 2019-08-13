using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish.ViewModels.ConnWindow
{
    /// <summary>
    /// The connection window.
    /// </summary>
    public class ConnWindow : Window
    {
        /// <summary>
        /// The connection window constructor
        /// </summary>
        public ConnWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializing the component.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}