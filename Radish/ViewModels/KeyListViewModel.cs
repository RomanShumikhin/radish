using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Radish.Interfaces;
using Radish.Models;
using Radish.Views.Errors;
using Splat;
using ReactiveUI;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the key list window.
    /// </summary>
    public class KeyListViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        private bool _isButtonEnabled = false;

        /// <summary>
        /// The selected key
        /// </summary>
        private KeyListItem _selectedKey;

        /// <summary>
        /// The constructor for the key List View Model
        /// </summary>
        public KeyListViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbSelected += DbSelected;
            _redisConn.KeyAdded += DbKeyAdded;
            this.ListOfKeys = new ObservableCollection<KeyListItem>();
        }

        /// <summary>
        /// The List of DB Numbers
        /// </summary>
        /// <value></value>
        public ObservableCollection<KeyListItem> ListOfKeys { get; }

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        public bool IsButtonEnabled 
        {
            get => _isButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isButtonEnabled, value);
        }

        /// <summary>
        /// This is our selected key.
        /// </summary>
        /// <value>The selected key</value>
        public KeyListItem SelectedKey
        {
            get => _selectedKey;
            set 
            {
                this.RaiseAndSetIfChanged(ref _selectedKey, value);

                if (value != null)
                {
                    this.SelectKey();
                }
            }
        }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void DbSelected(object sender, EventArgs e)
        {
            RefreshKeys();

            if (this.ListOfKeys.Count > 0)
            {
                this.SelectedKey = this.ListOfKeys[0];
                this.SelectKey();
            }
        }

        /// <summary>
        /// This is for when a key is added.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void DbKeyAdded(object sender, EventArgs e)
        {
            RefreshKeys();
        }

        /// <summary>
        /// The method to refresh the keys.
        /// </summary>
        public void RefreshKeys()
        {
            this.IsButtonEnabled = true;
            this.ListOfKeys.Clear();
            foreach (var key in _redisConn.GetKeys())
            {
                var keyItem = new KeyListItem(key);
                this.ListOfKeys.Add(keyItem);
            }
        }

        /// <summary>
        /// This selects the key to display.
        /// </summary>
        public void SelectKey()
        {
            try
            {
                _redisConn.GetStringKeyValue(SelectedKey.KeyName);
            }
            catch (Exception ex)
            {
                var window = new ErrorWindow()
                {
                    DataContext = new ErrorWindowViewModel("Error", ex.Message)
                };

                window.ShowDialog(Application.Current.MainWindow);
            }
        }
    }
}