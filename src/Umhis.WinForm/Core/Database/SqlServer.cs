using System.Data.SqlClient;

namespace Umhis.Core.Database
{
    public static class SqlServer
    {
        public static SqlConnectionStringBuilder ConnectionBuilder;


        public static SqlConnection CreateAndOpenConnection()
        {
            if (ConnectionBuilder == null)
            {
                ConnectionBuilder = new SqlConnectionStringBuilder()
                {
                    DataSource = "(LocalDB)\\MSSQLLocalDB",
                    AttachDBFilename = "|DataDirectory|\\Data\\database.mdf",
                    IntegratedSecurity = true,
                };
            }

            var db = new SqlConnection(ConnectionBuilder.ToString());

            db.Open();

            return db;
        }
    }
}
