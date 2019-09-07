using System;
using Avalonia;
using Radish.Interfaces;
using Radish.Views.Errors;
using ReactiveUI;
using Splat;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the connection window
    /// </summary>
    public class ConnWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis util
        /// </summary>
        public readonly IRedisUtils _redisConn;

        /// <summary>
        /// Whether or not the user has logged in.
        /// </summary>
        private bool _isLoggedIn = false;

        /// <summary>
        /// Whether or not the user has logged in.
        /// </summary>
        /// <value>Whether or not the user has logged in</value>
        public bool IsLoggedIn 
        {
            get => _isLoggedIn;
            set => this.RaiseAndSetIfChanged(ref _isLoggedIn, value);
        }

        /// <summary>
        /// The conn window view model
        /// </summary>
        public ConnWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            this.Host = "localhost";
            this.Port = "6379";

            this.IsLoggedIn = _redisConn.IsConnected();
            if (this.IsLoggedIn == true)
            {
                this.Host = _redisConn.GetBaseConnInfo().Address;
                this.Port = _redisConn.GetBaseConnInfo().Port.ToString();
            }
        }

        /// <summary>
        /// The redis host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The redis port
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Attempt to login
        /// </summary>
        public void AttemptLogin()
        {
            try
            {
                _redisConn.Connect(this.Host, Convert.ToInt32(this.Port));
                this.IsLoggedIn = _redisConn.IsConnected();
            }
            catch (Exception ex)
            {
                this.IsLoggedIn = false;
                var window = new ErrorWindow()
                {
                    DataContext = new ErrorWindowViewModel("Error", ex.Message)
                };

                window.ShowDialog(Application.Current.MainWindow);
            }
        }
    }
}