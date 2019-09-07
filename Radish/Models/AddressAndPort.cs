namespace Radish.Models
{
    /// <summary>
    /// This is the address and port for the redis view.
    /// </summary>
    public class AddressAndPort
    {
        /// <summary>
        /// This is the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// This is the port for the server.
        /// </summary>
        /// <value>This is the port for the server.</value>
        public int Port { get; set; }
    }
}