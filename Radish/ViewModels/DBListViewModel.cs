using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Radish.Interfaces;
using Radish.Models;
using Radish.Views.Errors;
using Splat;
using ReactiveUI;

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
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        private bool _isButtonEnabled = false;

        /// <summary>
        /// This is the field for the selected db.
        /// </summary>
        private DbListItem _selectedDb = null;

        /// <summary>
        /// This is the selected db from the UI.
        /// </summary>
        /// <value></value>
        public DbListItem SelectedDb { 
            get => _selectedDb;
            set 
            {
                this.IsButtonEnabled = true;
                this.RaiseAndSetIfChanged(ref _selectedDb, value);
            }
        }

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
        /// <param name="sender">the sender</param>
        /// <param name="e">The event arguments.</param>
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
            try
            {
                Console.WriteLine("Selecting " + this.SelectedDb.DbDisplay);
                _redisConn.SelectDb(this.SelectedDb.DbNumber);
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