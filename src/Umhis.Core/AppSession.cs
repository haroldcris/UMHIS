using System.Data;
using System.Data.SqlClient;
using Umhis.Core.Account;
using Umhis.Core.Data;

namespace Umhis.Core
{
    public class AppSession
    {
        public UserAccount CurrentUser { get; private set; }

        public bool Create(string username, string password)
        {
            using (var db = Database.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Account_Open", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 40).Value = username;


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        var item = new UserAccount (EntityRecordStatus.NoChanges)
                        {
                            Id       = reader.GetInt32From("Id"),
                            Username = reader.GetStringFrom("Username"),
                            Password = reader.GetStringFrom("Password"),
                            RowId    = reader.GetGuidFrom("RowId"),
                            RecordInfo =
                            {
                                CreatedDate  = reader.GetDateTimeFrom("Created"),
                                ModifiedDate = reader.GetDateTimeFrom("Modified"),
                                CreatedBy    = reader.GetStringFrom("CreatedBy"),
                                ModifiedBy   = reader.GetStringFrom("ModifiedBy")
                            }
                        };

                        //item.StartTrackingObject();

                        CurrentUser = item;

                        return true;
                    }
                }
            }

        }

    }

}

