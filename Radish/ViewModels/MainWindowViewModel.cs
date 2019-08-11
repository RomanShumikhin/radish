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
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRedisUtils _redisConn;

        public MainWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            ConnectCommand = ReactiveCommand.Create(RunConnectWindow);
        }

        public string Greeting => "Hello World!";

        public ReactiveCommand<Unit, Unit> ConnectCommand { get; set; }

        public void RunConnectWindow()
        {
            var window = new ConnWindow.ConnWindow
            {
                DataContext = new ConnWindowViewModel(),
            };

            window.ShowDialog(Application.Current.MainWindow);
        }

        public void AppExit()
        {
            App.Current.Exit();
        }
    }
}
