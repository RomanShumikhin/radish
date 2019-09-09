using StackExchange.Redis;

namespace Radish.Models
{
    /// <summary>
    /// This is for our key list.
    /// </summary>
    public class KeyListItem
    {
        /// <summary>
        /// The key name.
        /// </summary>
        /// <value>The name</value>
        public string KeyName {get; private set;}

        /// <summary>
        /// This is the key value.
        /// </summary>
        /// <value>the key value.</value>
        public string KeyValue {get; private set;}

        /// <summary>
        /// This is the redis type for the keys.
        /// </summary>
        /// <value>redis type for the key</value>
        public RedisType KeyRedisType {get; private set;}

        /// <summary>
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key"></param>
        public KeyListItem(string key, RedisType keyRedisType)
        {
            this.KeyName = key;
            this.KeyRedisType = keyRedisType;
        }

        /// <summary>
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public KeyListItem(string key, string value, RedisType keyRedisType)
        {
            this.KeyName = key;
            this.KeyValue = value;
            this.KeyRedisType = keyRedisType;
        }
    }
}