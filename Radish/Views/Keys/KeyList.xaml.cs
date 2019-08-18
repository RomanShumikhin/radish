using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Keys
{
    /// <summary>
    /// The Key list class.
    /// </summary>
    public class KeyList : UserControl
    {
        /// <summary>
        /// The key list constructor.
        /// </summary>
        public KeyList()
        {
            this.DataContext = new KeyListViewModel();
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