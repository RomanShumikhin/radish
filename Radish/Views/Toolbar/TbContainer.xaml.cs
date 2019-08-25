using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Radish.ViewModels;

namespace Radish.Views.Toolbar
{
    /// <summary>
    /// The toolbar view
    /// </summary>
    public class TbContainer : UserControl
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public TbContainer()
        {
            DataContext = new TbContainerViewModel();
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