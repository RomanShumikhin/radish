using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Radish.Interfaces;
using Radish.Models;
using Splat;

namespace Radish.ViewModels
{
    public class DBListViewModel : ViewModelBase
    {
        private readonly IRedisUtils _redisConn;

        public DBListViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbConnected += DbConnected;
        }

        public ObservableCollection<DbListItem> ListOfDbNumbers = new ObservableCollection<DbListItem>();

        private void DbConnected(object sender, EventArgs e)
        {
            Console.WriteLine("DBList - The db was connected.");
            this.ListOfDbNumbers.Clear();
            foreach(var dbi in _redisConn.GetDatabases())
            {
                DbListItem item = new DbListItem(dbi);
                this.ListOfDbNumbers.Add(item);
                Console.WriteLine("DBList - Added" + dbi.ToString());
            }
        }
    }
}