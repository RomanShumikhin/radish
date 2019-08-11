using StackExchange.Redis;
using System.Collections.Generic;

namespace Radish.Interfaces
{
    public interface IRedisUtils
    {
         bool Connect(string host, int port);

         bool Connect(string host, int port, ConfigurationOptions configOptions);

         List<int> GetDatabases();

         List<string> GetKeys(int db);
    }
}