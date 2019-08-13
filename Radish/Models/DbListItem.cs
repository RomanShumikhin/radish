namespace Radish.Models
{
    /// <summary>
    /// The DB List Item
    /// </summary>
    public class DbListItem
    {
        /// <summary>
        /// The DB number
        /// </summary>
        /// <value></value>
        public int DbNumber { get; set; }

        /// <summary>
        /// The DB Display
        /// </summary>
        /// <value></value>
        public string DbDisplay { get; set; }

        /// <summary>
        /// The constructor for the DB list item
        /// </summary>
        /// <param name="dbNumber"></param>
        public DbListItem(int dbNumber)
        {
            DbNumber = dbNumber;
            DbDisplay = "DB-" + DbNumber;
        }
    }
}