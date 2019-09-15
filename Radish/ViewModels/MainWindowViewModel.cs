using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Radish.Interfaces;
using ReactiveUI;
using Splat;
using Radish.ViewModels.ConnWindow;
using Avalonia;
using Radish.Views.StringView;
using Radish.Models;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the main window
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utils connection
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        private bool _isButtonEnabled = false;

        private bool _isIncrButtonEnabled = false;

        /// <summary>
        /// The seected key value.
        /// </summary>
        /// <value>The seected key value.</value>
        public KeyListItem SelectedKeyValue { get; set; }

        /// <summary>
        /// The main window VM constructor
        /// </summary>
        public MainWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbSelected += DbSelected;
            _redisConn.StringKeySelected += StringKeySelected;
            ConnectCommand = ReactiveCommand.Create(RunConnectWindow);
        }

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        public bool IsButtonEnabled 
        {
            get => _isButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isButtonEnabled, value);
        }

        public bool IsIncrButtonEnabled 
        {
            get => _isIncrButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isIncrButtonEnabled, value);
        }

        /// <summary>
        /// The connect command.
        /// </summary>
        /// <value></value>
        public ReactiveCommand<Unit, Unit> ConnectCommand { get; set; }

        /// <summary>
        /// Opens the connection window
        /// </summary>
        public void RunConnectWindow()
        {
            var window = new ConnWindow.ConnWindow()
            {
                DataContext = new ConnWindowViewModel()
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        public void AppExit()
        {
            App.Current.Exit();
        }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void DbSelected(object sender, EventArgs e)
        {
            this.IsButtonEnabled = true;
        }

        /// <summary>
        /// Fires when the key is selected.
        /// </summary>
        /// <param name="sender">The key list item.</param>
        /// <param name="e">The event args.</param>
        private void StringKeySelected(object sender, EventArgs e)
        {
            this.SelectedKeyValue = (KeyListItem)sender;
            if (this.SelectedKeyValue.IsNumeric)
            {
                this.IsIncrButtonEnabled = true;
            }
            else
            {
                this.IsIncrButtonEnabled = false;
            }
        }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public void OnAddKey()
        {
            var window = new AddStringKey()
            {
                DataContext = new AddStringKeyViewModel()
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        private void OnIncrementString()
        {
            _redisConn.IncrementStringKeyValue(this.SelectedKeyValue.KeyName);
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        private void OnDecrementString()
        {
            _redisConn.DecrementStringKeyValue(this.SelectedKeyValue.KeyName);
        }
    }
}
