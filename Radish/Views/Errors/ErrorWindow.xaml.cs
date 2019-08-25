using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Radish.Views.Errors
{
    /// <summary>
    /// The error window view.
    /// </summary>
    public class ErrorWindow : Window
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public ErrorWindow()
        {
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
        /// <param name="e">The events args</param>
        private void CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}