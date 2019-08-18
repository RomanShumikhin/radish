using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Radish.Interfaces;
using Radish.Models;
using Splat;

namespace Radish.ViewModels
{
    public class KeyListViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The constructor for the DB List View Model
        /// </summary>
        public KeyListViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbSelected += DbSelected;
            this.ListOfKeys = new ObservableCollection<KeyListItem>();
        }

        /// <summary>
        /// The List of DB Numbers
        /// </summary>
        /// <value></value>
        public ObservableCollection<KeyListItem> ListOfKeys { get; }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbSelected(object sender, EventArgs e)
        {
            Console.WriteLine("DBKeys - The db was connected.");
            this.ListOfKeys.Clear();
            foreach (var key in _redisConn.GetKeys())
            {
                var keyItem = new KeyListItem(key);
                this.ListOfKeys.Add(keyItem);
                Console.WriteLine("Key List - Added: " + key);
            }
        }
    }
}