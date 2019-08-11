using Radish.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Radish.DIServices
{
    public class RedisUtils : IRedisUtils
    {
        private ConnectionMultiplexer _redis = null;

        private string _host = null;

        private int _port = 0;

        private ConfigurationOptions _configOptions = null;

        public RedisUtils()
        {

        }

        public bool Connect(string host, int port)
        {
            bool retval = false;

            _redis = ConnectionMultiplexer.Connect(host + ":" + port.ToString());
            _host = host;
            _port = port;
            _configOptions = ConfigurationOptions.Parse(_redis.Configuration);
            Console.WriteLine(_redis.GetStatus());
            return retval;
        }

        public bool Connect(string host, int port, ConfigurationOptions configOptions)
        {
            bool retval = true;
            _configOptions = configOptions;
            _host = host;
            _port = port;
            _redis = ConnectionMultiplexer.Connect(_configOptions);
            Console.WriteLine(_redis.GetStatus());
            return retval;
        }

        public List<int> GetDatabases()
        {
            List<int> myDbs = new List<int>();
            if (_redis != null)
            {
                int count = _redis.GetServer(_host, _port).DatabaseCount;
                for (int i = 0; i < count; i++)
                {
                    myDbs.Add(i);
                }
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }

            return myDbs;
        }

        public List<string> GetKeys(int db)
        {
            List<string> myKeys = new List<string>();
            if (_redis != null)
            {
                foreach (var key in _redis.GetServer(_host, _port).Keys(db))
                {
                    myKeys.Add(key);
                }
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }

            return myKeys;
        }
    }
}