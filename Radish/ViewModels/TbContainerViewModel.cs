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
        /// The constructor for the DB List View Model
        /// </summary>
        public TbContainerViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbSelected += DbSelected;
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
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public void OnAddKey()
        {
            var window = new AddKey()
            {
                DataContext = new TbContainerViewModel()
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

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
    }
}