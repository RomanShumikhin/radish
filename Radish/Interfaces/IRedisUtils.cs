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
        /// Gets the selected Db
        /// </summary>
        /// <returns></returns>
        int GetSelectedDb();

        /// <summary>
        /// Gets whether the redis instance is connected.
        /// </summary>
        /// <returns></returns>
        bool IsConnected();

        /// <summary>
        /// Selects the DB number.
        /// </summary>
        /// <param name="dbNumber">the DB number</param>
         void SelectDb(int dbNumber);

        /// <summary>
        /// Connection with no additional configuration.
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port number</param>
        /// <returns></returns>
         bool Connect(string host, int port);

        /// <summary>
        /// Connection with additional configuration options.
        /// </summary>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="configOptions">The configuration options.</param>
        /// <returns></returns>
         bool Connect(string host, int port, ConfigurationOptions configOptions);

        /// <summary>
        /// Gets all the databases for the redis install.
        /// </summary>
        /// <returns>The list of the databases</returns>
         List<int> GetDatabases();

        /// <summary>
        /// Gets the keys for a database
        /// </summary>
        /// <returns>The list of the keys.</returns>
         List<string> GetKeys();

        /// <summary>
        /// This deletes all the keys in the db.
        /// </summary>
        void DeleteKeys();

        /// <summary>
        /// Sets a key value to the selected db
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The string value.</param>
         void AddStringKeyValue(string key, string value);

        /// <summary>
        /// This is going to get the string value.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The key string value.</returns>
         string GetStringKeyValue(string key);
    }
}