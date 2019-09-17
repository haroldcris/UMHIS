using System.Data.SqlClient;

namespace Umhis.Core.Data
{
    internal static class Database
    {
        public static SqlConnection CreateAndOpenConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = "(LocalDB)\\MSSQLLocalDB",
                AttachDBFilename = "|DataDirectory|\\Data\\database.mdf",
                IntegratedSecurity = true,
            };

            var db = new SqlConnection(builder.ToString());

            db.Open();

            return db;
        }
    }
}
