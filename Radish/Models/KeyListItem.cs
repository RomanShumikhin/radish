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
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key"></param>
        public KeyListItem(string key)
        {
            this.KeyName = key;
        }
    }
}