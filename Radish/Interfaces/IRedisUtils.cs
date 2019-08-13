using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Radish.Interfaces
{
    public interface IRedisUtils
    {
         event EventHandler DbConnected;

         event EventHandler DbSelected;

         void SelectDb(int dbNumber);

         bool Connect(string host, int port);

         bool Connect(string host, int port, ConfigurationOptions configOptions);

         List<int> GetDatabases();

         List<string> GetKeys(int db);
    }
}