using System;
using Radish.Interfaces;
using Splat;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using Radish.Views.Errors;
using Avalonia;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the View Model to add a key to the redis DB.
    /// </summary>
    public class AddStringKeyViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis util
        /// </summary>
        public readonly IRedisUtils _redisConn;

        /// <summary>
        /// The conn window view model
        /// </summary>
        public AddStringKeyViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
        }

        /// <summary>
        /// The redis host
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// The redis port
        /// </summary>
        public string KeyValue { get; set; }

        /// <summary>
        /// Attempt to login
        /// </summary>
        public void AddKeyValue()
        {
            try
            {
                _redisConn.AddStringKeyValue(this.KeyName, this.KeyValue);
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