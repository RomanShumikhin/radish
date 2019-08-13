using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Radish.Interfaces;
using ReactiveUI;
using Splat;
using Radish.ViewModels.ConnWindow;
using Avalonia;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the main window
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utils connection
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The main window VM constructor
        /// </summary>
        public MainWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            ConnectCommand = ReactiveCommand.Create(RunConnectWindow);
        }

        /// <summary>
        /// The connect command.
        /// </summary>
        /// <value></value>
        public ReactiveCommand<Unit, Unit> ConnectCommand { get; set; }

        /// <summary>
        /// Opens the connection window
        /// </summary>
        public void RunConnectWindow()
        {
            var window = new ConnWindow.ConnWindow
            {
                DataContext = new ConnWindowViewModel(),
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        public void AppExit()
        {
            App.Current.Exit();
        }
    }
}
