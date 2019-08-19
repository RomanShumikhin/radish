using System;
using Radish.Interfaces;
using Splat;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace Radish.ViewModels
{
    public class AddKeyViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis util
        /// </summary>
        public readonly IRedisUtils _redisConn;

        /// <summary>
        /// The conn window view model
        /// </summary>
        public AddKeyViewModel()
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
            _redisConn.AddStringKeyValue(this.KeyName, this.KeyValue);
        }
    }
}