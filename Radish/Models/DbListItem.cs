namespace Radish.Models
{
    public class DbListItem
    {
        public int DbNumber { get; set; }
        public string DbDisplay { get; set; }

        public DbListItem(int dbNumber)
        {
            DbNumber = dbNumber;
            DbDisplay = "DB-" + DbNumber;
        }
    }
}