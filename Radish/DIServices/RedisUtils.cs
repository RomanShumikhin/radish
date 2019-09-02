using Radish.Interfaces;
using Radish.Models;
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
        private int _selectedDb = -1;

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
        /// Key added
        /// </summary>
        public event EventHandler KeyAdded;

        /// <summary>
        /// The key is selected
        /// </summary>
        public event EventHandler KeySelected;

        /// <summary>
        /// The redis utils constructor
        /// </summary>
        public RedisUtils()
        {

        }

        /// <summary>
        /// This fires the key selected event.
        /// </summary>
        /// <param name="value">the key value.</param>
        /// <param name="e">The events args</param>
        protected virtual void OnKeySelected(KeyListItem value, EventArgs e)
        {
            EventHandler handler = KeySelected;
            handler?.Invoke(value, e);
        }

        /// <summary>
        /// This fires the key added event.
        /// </summary>
        /// <param name="e">The event args</param>
        protected virtual void OnKeyAdded(EventArgs e)
        {
            EventHandler handler = KeyAdded;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Firing the on db connected.
        /// </summary>
        /// <param name="e">The event args</param>
        protected virtual void OnDbConnected(EventArgs e)
        {
            EventHandler handler = DbConnected;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Firing the on db seleced.
        /// </summary>
        /// <param name="e">The events args</param>
        protected virtual void OnDbSelected(EventArgs e)
        {
            EventHandler handler = DbSelected;
            handler?.Invoke(this._selectedDb, e);
        }

        /// <summary>
        /// Selects the DB number.
        /// </summary>
        /// <param name="dbNumber">The db number</param>
        public void SelectDb(int dbNumber)
        {
            this._selectedDb = dbNumber;
            this.OnDbSelected(new EventArgs());
        }

        /// <summary>
        /// Gets the selected Db
        /// </summary>
        /// <returns>The selected db number.</returns>
        public int GetSelectedDb()
        {
            return this._selectedDb;
        }

        /// <summary>
        /// Gets whether the redis instance is connected.
        /// </summary>
        /// <returns>Whether it is connected.</returns>
        public bool IsConnected()
        {
            bool retval = false;

            if (this._redis != null)
            {
                retval = true;
            }

            return retval;
        }

        /// <summary>
        /// Connection with no additional configuration.
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <returns>Whether or not it connected.</returns>
        public bool Connect(string host, int port)
        {
            bool retval = false;

            _redis = ConnectionMultiplexer.Connect(host + ":" + port.ToString());
            _host = host;
            _port = port;
            _configOptions = ConfigurationOptions.Parse(_redis.Configuration);
            this.OnDbConnected(new EventArgs());
            return retval;
        }

        /// <summary>
        /// Connection with additional configuration options.
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="configOptions">The configuration options</param>
        /// <returns>Whether or not it connected.</returns>
        public bool Connect(string host, int port, ConfigurationOptions configOptions)
        {
            bool retval = true;
            _configOptions = configOptions;
            _host = host;
            _port = port;
            _redis = ConnectionMultiplexer.Connect(_configOptions);
            this.OnDbConnected(new EventArgs());
            return retval;
        }

        /// <summary>
        /// Gets all the databases for the redis install.
        /// </summary>
        /// <returns>Get the database list or integers.</returns>
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
        /// <returns>The list of keys</returns>
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

        /// <summary>
        /// This deletes all the keys in the db.
        /// </summary>
        public void DeleteKeys()
        {
            if (_redis != null)
            {
                var db = _redis.GetDatabase(this._selectedDb);
                foreach (var key in this.GetKeys())
                {
                    db.KeyDelete(key);
                }
                this.OnKeyAdded(new EventArgs());
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }
        }

        /// <summary>
        /// This added string key value.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void AddStringKeyValue(string key, string value)
        {
            if (_redis != null)
            {
                var db = _redis.GetDatabase(this._selectedDb);
                db.StringSet(key, value);
                this.OnKeyAdded(new EventArgs());
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }
        }

        /// <summary>
        /// This gets the string value.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>the selected string value</returns>
        public string GetStringKeyValue(string key)
        {
            string retval = string.Empty;

            if (_redis != null)
            {
                var db = _redis.GetDatabase(this._selectedDb);
                retval = db.StringGet(key);
                this.OnKeySelected(new KeyListItem(key, retval), new EventArgs());
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }

            return retval;
        }

        /// <summary>
        /// Deletes a key from Redis
        /// </summary>
        /// <param name="key">The key name.</param>
        public void DeleteKey(string key)
        {
            if (_redis != null)
            {
                var db = _redis.GetDatabase(this._selectedDb);
                db.KeyDelete(key);
                this.OnKeyAdded(new EventArgs());
            }
            else
            {
                throw new Exception("Not Connected to Redis");
            }
        }
    }
}