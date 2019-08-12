namespace Radish.Models
{
    public class DbListItem
    {
        public int DbNumber { get; private set; }
        public string DbDisplay { get; private set; }

        public DbListItem(int dbNumber)
        {
            DbNumber = dbNumber;
            DbDisplay = "DB-" + DbNumber;
        }
    }
}