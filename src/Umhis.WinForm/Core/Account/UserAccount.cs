using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Umhis.Core.Database;

namespace Umhis.Core
{
    public class UserAccount : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecurityLevel { get; set; }
        public bool Active { get; set; }


        public override string ToString()
        {
            return Username;
        }


        public bool Save(string currentUser)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("UserAccount_Save", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


                    cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 30).Value   = DisplayName;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 40).Value      = Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value     = Password;
                    cmd.Parameters.Add("@SecurityLevel", SqlDbType.NVarChar, 20).Value = SecurityLevel;
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value                 = Active;
                    cmd.Parameters.Add("@Encoder", SqlDbType.NVarChar, 40).Value       = currentUser;


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        Id = reader.GetInt32From("Id");
                        RecordInfo.LoadValuesFrom(reader);
                    }
                }
            }


            return true;
        }


        public bool Delete(string currentUser)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("UserAccount_Delete", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    var ret = cmd.ExecuteNonQuery();
                    if (ret == 0) throw new Exception("Command has been executed but No results. No changes has been made in the database.");
                }
            }

            return true;
        }

        public static IEnumerable<UserAccount> GetItems()
        {
            var itemCollection = new List<UserAccount>();

            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("UserAccount_List", db) { CommandType = CommandType.StoredProcedure })
                {

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var item = new UserAccount();

                            item.Id                      = reader.GetInt32From("Id");
                            item.DisplayName             = reader.GetStringFrom("DisplayName");
                            item.Username                = reader.GetStringFrom("Username");
                            item.Password                = reader.GetStringFrom("Password");
                            item.SecurityLevel           = reader.GetStringFrom("SecurityLevel");
                            item.Active                  = reader.GetBooleanFrom("Active");

                            item.RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                            item.RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                            item.RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                            item.RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");

                            itemCollection.Add(item);
                        }
                    }
                }
            }

            return itemCollection;

        }

        public bool LoadItem(string username)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("UserAccount_Open", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 40).Value = username;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        Id                      = reader.GetInt32From("Id");
                        DisplayName             = reader.GetStringFrom("DisplayName");
                        Username                = reader.GetStringFrom("Username");
                        Password                = reader.GetStringFrom("Password");
                        SecurityLevel           = reader.GetStringFrom("SecurityLevel");
                        Active                  = reader.GetBooleanFrom("Active");
                        RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                        RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                        RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                        RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");

                        return true;
                    }
                }
            }

        }
    }
}
