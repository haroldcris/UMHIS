using System.Data.SqlClient;
using Umhis.Core.Data;

namespace Umhis.Core
{
    internal abstract class BaseDataWriter<T> where T: BaseEntity
    {
        protected readonly T _baseEntity;
        protected readonly string _currentUsername;

        protected BaseDataWriter(string username, T baseEntity)
        {
            _baseEntity = baseEntity;
            _currentUsername = username;
        }


        protected abstract SqlCommand GetCreateCommand();
        protected abstract SqlCommand GetUpdateCommand();
        protected abstract SqlCommand GetDeleteCommand();



        private SqlCommand DetectCommandToExecute(out bool IsDeleteCommand)
        {
            SqlCommand cmd;
            IsDeleteCommand = false;

            switch (_baseEntity.RecordStatus)
            {
                case EntityRecordStatus.DeletedRecord:
                    cmd = GetDeleteCommand();
                    IsDeleteCommand = true;
                    break;

                case EntityRecordStatus.ModifiedRecord:
                    cmd = GetUpdateCommand();
                    break;

                case EntityRecordStatus.NewRecord:
                    cmd = GetCreateCommand();
                    break;

                default:
                    cmd = null;
                    break;
            }

            return cmd;
        }


        public bool SaveChanges()
        {
            using (var db = Database.CreateAndOpenConnection())
            {
                using (var cmd = DetectCommandToExecute(out var isDeleteCommand))
                {
                    if (cmd == null) return false;

                    cmd.Connection = db;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (isDeleteCommand) return true;

                        if (!reader.Read()) return false;

                        _baseEntity.Id = reader.GetInt32From("Id");
                        _baseEntity.RecordInfo.LoadValuesFrom(reader);
                    }
                }
                return true;
            }
        }


    }
}