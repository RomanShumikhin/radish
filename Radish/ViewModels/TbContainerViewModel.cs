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
    public class TbContainerViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The constructor for the DB List View Model
        /// </summary>
        public TbContainerViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
        }

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnAddKey()
        {
            var window = new AddKey()
            {
                DataContext = new TbContainerViewModel()
            };

            window.ShowDialog(Application.Current.MainWindow);
        }
    }
}