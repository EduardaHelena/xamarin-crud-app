using Microsoft.Data.Sqlite;

namespace XamarinMobileApp.Repositories
{
    public static class ConnectionHelper
    {
        public static SqliteConnection Create()
        {
            return new SqliteConnection("Data Source=sqlite.db");
        }
    }
}
