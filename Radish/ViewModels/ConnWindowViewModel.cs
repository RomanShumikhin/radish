using System;
using Avalonia;
using Radish.Interfaces;
using Radish.Views.Errors;
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
        /// The conn window view model
        /// </summary>
        public ConnWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            this.Host = "localhost";
            this.Port = "6379";
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

                var window = new ErrorWindow()
                {
                    DataContext = new ErrorWindowViewModel("Message", "Connection Successful")
                };

                window.ShowDialog(Application.Current.MainWindow);
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