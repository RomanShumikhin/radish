using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish.Views
{
    /// <summary>
    /// The main window class.
    /// </summary>
    public class MainWindow : Window
    {
        /// <summary>
        /// The main window constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the component.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}