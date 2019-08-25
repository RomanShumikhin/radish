using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

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