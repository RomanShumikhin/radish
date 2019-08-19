using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Radish.Interfaces
{
    /// <summary>
    /// This is the Redis Utils Interface
    /// </summary>
    public interface IRedisUtils
    {
        /// <summary>
        /// The DB connected event handler
        /// </summary>
         event EventHandler DbConnected;

        /// <summary>
        /// The DB selected event handler
        /// </summary>
         event EventHandler DbSelected;

        /// <summary>
        /// Key added
        /// </summary>
         event EventHandler KeyAdded;

        /// <summary>
        /// This is the event for selecting a key.
        /// </summary>
         event EventHandler KeySelected;

        /// <summary>
        /// Selects the DB number.
        /// </summary>
        /// <param name="dbNumber"></param>
         void SelectDb(int dbNumber);

        /// <summary>
        /// Connection with no additional configuration.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
         bool Connect(string host, int port);

        /// <summary>
        /// Connection with additional configuration options.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="configOptions"></param>
        /// <returns></returns>
         bool Connect(string host, int port, ConfigurationOptions configOptions);

        /// <summary>
        /// Gets all the databases for the redis install.
        /// </summary>
        /// <returns></returns>
         List<int> GetDatabases();

        /// <summary>
        /// Gets the keys for a database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
         List<string> GetKeys();

        /// <summary>
        /// Sets a key value to the selected db
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
         void AddStringKeyValue(string key, string value);

        /// <summary>
        /// This is going to get the string value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
         string GetStringKeyValue(string key);
    }
}