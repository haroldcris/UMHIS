using System.Data;
using System.Data.SqlClient;

namespace Umhis.Core.Account
{
    internal class UserAccountDataWriter : BaseDataWriter<UserAccount>
    {
        private readonly UserAccount _item;
        public UserAccountDataWriter(string currentUser, UserAccount item) : base(currentUser, item)
        {
            _item = item;
        }
        

        protected override SqlCommand GetCreateCommand()
        {
            var cmd = new SqlCommand("Account_Save") {CommandType = CommandType.StoredProcedure};

            CreateCommandParameters(cmd);
            return cmd;
        }


        private void CreateCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 40).Value  = _item.Username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = _item.Password;
            cmd.Parameters.Add("@RowId", SqlDbType.UniqueIdentifier).Value = _item.RowId;
            cmd.Parameters.Add("Encoder", SqlDbType.NVarChar, 40).Value    = _currentUsername;
        }

        protected override SqlCommand GetUpdateCommand()
        {
            var cmd = new SqlCommand("Account_Save") {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _item.Id;
            CreateCommandParameters(cmd);
            return cmd;
        }

        protected override SqlCommand GetDeleteCommand()
        {
            var cmd = new SqlCommand("Account_Delete") {CommandType = CommandType.StoredProcedure};

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = _item.Id;
            return cmd;
        }
    }
}
