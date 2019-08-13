using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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