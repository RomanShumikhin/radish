using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
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
        /// This is the selected db from the UI.
        /// </summary>
        /// <value></value>
        public DbListItem SelectedDb { get; set; }

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

        /// <summary>
        /// Selects the db.
        /// </summary>
        /// <param name="dbi"></param>
        public void OnDbSelected()
        {
            Console.WriteLine("Selecting " + this.SelectedDb.DbDisplay);
            _redisConn.SelectDb(this.SelectedDb.DbNumber);
        }
    }
}