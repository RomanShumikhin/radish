using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Radish.Interfaces;
using ReactiveUI;
using Splat;
using Radish.ViewModels.ConnWindow;
using Avalonia;
using Radish.Views.Toolbar;
using Radish.Models;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the toolbar container
    /// </summary>
    public class TbContainerViewModel : ViewModelBase
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
        /// This is whether or not we want out delete button enabled.
        /// </summary>
        private bool _isDeleteButtonEnabled = false;

        /// <summary>
        /// This is the selected key.
        /// </summary>
        private KeyListItem _selectedKey = null;

        /// <summary>
        /// The constructor for the DB List View Model
        /// </summary>
        public TbContainerViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbSelected += DbSelected;
            _redisConn.KeySelected += KeySelected;
            _redisConn.KeyAdded += DbKeyAdded;
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

        /// <summary>
        /// This is whether or not we want out delete button enabled.
        /// </summary>
        /// <value>This is whether or not we want out delete button enabled.</value>
        public bool IsDeleteButtonEnabled 
        {
            get => _isDeleteButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isDeleteButtonEnabled, value);
        }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public void OnAddKey()
        {
            var window = new AddKey()
            {
                DataContext = new AddKeyViewModel()
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

        /// <summary>
        /// The method to call the deleting of a key.
        /// </summary>
        public void OnDeleteKey()
        {
            _redisConn.DeleteKey(this._selectedKey.KeyName);
        }

        /// <summary>
        /// Flushes out the keys.
        /// </summary>
        public void OnFlushKeys()
        {
            _redisConn.DeleteKeys();
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
        /// Fires when we select a key.
        /// </summary>
        /// <param name="sender">The KeyListItem</param>
        /// <param name="e">The event arguments</param>
        private void KeySelected(object sender, EventArgs e)
        {
            this.IsDeleteButtonEnabled = true;
            this._selectedKey = (KeyListItem)sender;
        }

        /// <summary>
        /// Fires when the keys are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbKeyAdded(object sender, EventArgs e)
        {
            RefreshKeys();
        }

        /// <summary>
        /// The method to refresh the keys.
        /// </summary>
        public void RefreshKeys()
        {
            if (_redisConn.GetKeys().Count > 0)
            {
                this.IsButtonEnabled = true;
                this.IsDeleteButtonEnabled = false;
            }
            else
            {
                this.IsButtonEnabled = false;
                this.IsDeleteButtonEnabled = false;
            }
        }
    }
}