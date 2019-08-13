using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Radish.Interfaces;
using Radish.Models;
using Splat;

namespace Radish.ViewModels
{
    /// <summary>
    /// The DB List View Model
    /// </summary>
    public class DBListViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The constructor for the DB List View Model
        /// </summary>
        public DBListViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbConnected += DbConnected;
            this.ListOfDbNumbers = new ObservableCollection<DbListItem>();
        }

        /// <summary>
        /// The List of DB Numbers
        /// </summary>
        /// <value></value>
        public ObservableCollection<DbListItem> ListOfDbNumbers { get; }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbConnected(object sender, EventArgs e)
        {
            Console.WriteLine("DBList - The db was connected.");
            this.ListOfDbNumbers.Clear();
            foreach (var dbi in _redisConn.GetDatabases())
            {
                DbListItem item = new DbListItem(dbi);
                this.ListOfDbNumbers.Add(item);
                Console.WriteLine("DBList - Added" + dbi.ToString());
            }
        }
    }
}