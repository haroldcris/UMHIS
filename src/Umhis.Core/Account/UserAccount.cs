using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Umhis.Core.Data;

namespace Umhis.Core.Account
{
    public class UserAccount: BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAccount(EntityRecordStatus status) : base(status)
        {
            //
        }


        public bool Save(string currentUser)
        {
            var writer = new UserAccountDataWriter(currentUser, this);
            return writer.SaveChanges();
        }

        public override string ToString()
        {
            return Username;
        }



        public static IEnumerable<UserAccount> GetListOfUsers()
        {
            using (var db = Database.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Account_List", db) { CommandType = CommandType.StoredProcedure })
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var itemCollection = new List<UserAccount>();

                        while (reader.Read())
                        {
                            var item = new UserAccount( EntityRecordStatus.NoChanges);

                            item.Id                      = reader.GetInt32From("Id");
                            item.Username                = reader.GetStringFrom("Username");
                            item.Password                = reader.GetStringFrom("Password");
                            item.RowId                   = reader.GetGuidFrom("RowId");

                            item.RecordInfo.LoadValuesFrom(reader);

                            itemCollection.Add(item);
                        }

                        return itemCollection;
                    }
                }
            }

        }

        
    }
}
