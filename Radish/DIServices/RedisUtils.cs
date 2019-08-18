using Radish.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Radish.DIServices
{
    /// <summary>
    /// This is the redis utils implementation.
    /// </summary>
    public class RedisUtils : IRedisUtils
    {
        /// <summary>
        /// The redis connection.
        /// </summary>
        private ConnectionMultiplexer _redis = null;

        /// <summary>
        /// The host string.
        /// </summary>
        private string _host = null;

        /// <summary>
        /// The Connection port
        /// </summary>
        private int _port = 0;

        /// <summary>
        /// The selected DB number
        /// </summary>
        private int _selectedDb = 0;

        /// <summary>
        /// The DB configuration options
        /// </summary>
        private ConfigurationOptions _configOptions = null;

        /// <summary>
        /// The DB connected event handler
        /// </summary>
        public event EventHandler DbConnected;

        /// <summary>
        /// The DB selected event handler
        /// </summary>
        public event EventHandler DbSelected;

        /// <summary>
        /// The redis utils constructor
        /// </summary>
        public RedisUtils()
        {

        }

        /// <summary>
        /// Firing the on db connected.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDbConnected(EventArgs e)
        {
            EventHandler handler = DbConnected;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Firing the on db seleced.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDbSelected(EventArgs e)
        {
            EventHandler handler = DbSelected;
            handler?.Invoke(this._selectedDb, e);
        }

        /// <summary>
        /// Selects the DB number.
        /// </summary>
        /// <param name="dbNumber"></param>
        public void SelectDb(int dbNumber)
        {
            this._selectedDb = dbNumber;
            this.OnDbSelected(new EventArgs());
        }

        /// <summary>
        /// Connection with no additional configuration.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool Connect(string host, int port)
        {
            bool retval = false;

            _redis = ConnectionMultiplexer.Connect(host + ":" + port.ToString());
            _host = host;
            _port = port;
            _configOptions = ConfigurationOptions.Parse(_redis.Configuration);
            Console.WriteLine(_redis.GetStatus());
            this.OnDbConnected(new EventArgs());
            return retval;
        }

        /// <summary>
        /// Connection with additional configuration options.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="configOptions"></param>
        /// <returns></returns>
        public bool Connect(string host, int port, ConfigurationOptions configOptions)
        {
            bool retval = true;
            _configOptions = configOptions;
            _host = host;
            _port = port;
            _redis = ConnectionMultiplexer.Connect(_configOptions);
            Console.WriteLine(_redis.GetStatus());
            this.OnDbConnected(new EventArgs());
            return retval;
        }

        /// <summary>
        /// Gets all the databases for the redis install.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the keys for a database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            List<string> myKeys = new List<string>();
            if (_redis != null)
            {
                foreach (var key in _redis.GetServer(_host, _port).Keys(this._selectedDb))
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