using System.Data.SqlClient;

namespace Umhis.Core.Database
{
    internal static class SqlServer
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
