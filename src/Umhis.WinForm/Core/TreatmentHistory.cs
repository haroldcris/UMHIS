using System;
using System.Data;
using System.Data.SqlClient;
using Umhis.Core.Database;

namespace Umhis.Core
{
    public class TreatmentHistory : BaseEntity
    {
        public DateTime DateTreated { get; set; }
        public int PatientId { get; set; }
        public string Condition { get; set; }
        public string Treatment { get; set; }
        public string Remarks { get; set; }

        internal void LoadValuesFrom(IDataReader reader)
        {
            DateTreated = reader.GetDateTimeFrom("DateTreated");
            PatientId = reader.GetInt32From("PatientId");
            Condition = reader.GetStringFrom("Condition");
            Treatment = reader.GetStringFrom("Treatment");
            Remarks = reader.GetStringFrom("Remarks");
            RecordInfo.CreatedDate = reader.GetDateTimeFrom("created");
            RecordInfo.ModifiedDate = reader.GetDateTimeFrom("modified");
        }



        public bool Save(string currentUser)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                Save(currentUser, db);
            }
            return true;
        }


        public bool Save(string currentUser, SqlConnection db)
        {
            using (var cmd = new SqlCommand("TreatmentHistory_Save", db) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value                  = Id;
                cmd.Parameters.Add("@DateTreated", SqlDbType.Date).Value        = DateTreated;
                cmd.Parameters.Add("@PatientId", SqlDbType.Int).Value           = PatientId;
                cmd.Parameters.Add("@Condition", SqlDbType.NVarChar, 500).Value = Condition;
                cmd.Parameters.Add("@Treatment", SqlDbType.NVarChar, 500).Value = Treatment;
                cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 500).Value = Remarks;
                cmd.Parameters.Add("@Encoder", SqlDbType.NVarChar, 40).Value    = currentUser;


                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return false;

                    Id                      = reader.GetInt32From("Id");
                    RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                    RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                    RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                    RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");
                }
            }

            return true;
        }


        public bool Delete()
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("TreatmentHistory_Delete", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    var ret = cmd.ExecuteNonQuery();
                    if (ret == 0) throw new Exception("Command has been executed but No results. No changes has been made in the database.");
                }
            }
            return true;
        }
    }
}