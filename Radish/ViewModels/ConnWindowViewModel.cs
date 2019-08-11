using System;
using Radish.Interfaces;
using Splat;

namespace Radish.ViewModels
{
    public class ConnWindowViewModel : ViewModelBase
    {
        public readonly IRedisUtils _redisConn;

        public ConnWindowViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.DbConnected += DbConnected;
        }

        public string Host => "localhost";

        public string Port => "6379";

        public void AttemptLogin()
        {
            _redisConn.Connect(this.Host, Convert.ToInt32(this.Port));
        }

        private void DbConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Conn - The db was connected.");
        }
    }
}