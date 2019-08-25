using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Radish.ViewModels;

namespace Radish.Views.Toolbar
{
    /// <summary>
    /// The view for adding the key
    /// </summary>
    public class AddKey : Window
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public AddKey()
        {
            DataContext = new AddKeyViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// Initializes Component
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}