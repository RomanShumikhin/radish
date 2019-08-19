using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Radish.ViewModels;

namespace Radish.Views.Toolbar
{
    public class AddKey : Window
    {
        public AddKey()
        {
            DataContext = new AddKeyViewModel();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CloseThis(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}