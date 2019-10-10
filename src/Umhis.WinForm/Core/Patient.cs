using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Umhis.Core.Database;

namespace Umhis.Core
{
    public class Patient : BaseEntity
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string NameExtension { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Department { get; set; }
        public string BloodType { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Remarks { get; set; }

        public string Fullname => $"{Lastname} , {Firstname} {Middlename}{(NameExtension.Length == 0 ? "" : ", " + NameExtension)}";

        public int Age => DateTime.Today.Year - BirthDate.Year;

        public ICollection<TreatmentHistory> TreatmentHistoryItems { get; }

        public Patient()
        {
            Department = "";
            Height     = 1;
            Weight     = 1;
            BirthDate  = new DateTime(1920, 1, 1);
            Remarks    = "";

            TreatmentHistoryItems = new List<TreatmentHistory>();
        }


        public bool Save(string currentUser)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Patient_Save", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value                            = Id;
                    cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar, 50).Value             = Lastname;
                    cmd.Parameters.Add("@Firstname", SqlDbType.NVarChar, 50).Value            = Firstname;
                    cmd.Parameters.Add("@Middlename", SqlDbType.NVarChar, 50).Value           = Middlename;
                    cmd.Parameters.Add("@NameExtension", SqlDbType.NVarChar, 10).Value        = NameExtension;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value               = Gender;
                    cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value                    = BirthDate;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar, 30).Value           = Department;
                    cmd.Parameters.Add("@BloodType", SqlDbType.NVarChar, 5).Value             = BloodType;
                    cmd.Parameters.Add("@Height", SqlDbType.Decimal).Value                    = Height;
                    cmd.Parameters.Add("@Weight", SqlDbType.Decimal).Value                    = Weight;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 200).Value             = Remarks;
                    cmd.Parameters.Add("@Encoder", SqlDbType.NVarChar, 40).Value              = currentUser;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        Id = reader.GetInt32From("Id");
                        RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                        RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                        RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                        RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");

                    }
                }


                //Save SubItem
                foreach (var item in TreatmentHistoryItems)
                {
                    item.PatientId = Id;
                    item.Save(currentUser, db);
                }
            }

            return true;
        }


        public bool Delete()
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Patient_Delete", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;
                    }
                }
            }

            return true;
        }


        public bool LoadById(int idNumber)
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Patient_OpenById", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = idNumber;


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read()) return false;

                        Id            = reader.GetInt32From("Id");
                        Lastname      = reader.GetStringFrom("Lastname");
                        Firstname     = reader.GetStringFrom("Firstname");
                        Middlename    = reader.GetStringFrom("Middlename");
                        NameExtension = reader.GetStringFrom("NameExtension");
                        Gender        = reader.GetStringFrom("Gender");
                        BirthDate     = reader.GetDateTimeFrom("BirthDate");
                        Department    = reader.GetStringFrom("Department");
                        BloodType     = reader.GetStringFrom("BloodType");
                        Height        = reader.GetDecimalFrom("Height");
                        Weight        = reader.GetDecimalFrom("Weight");
                        Remarks       = reader.GetStringFrom("Remarks");

                        RecordInfo.LoadValuesFrom(reader);
                        //RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                        //RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                        //RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                        //RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");
                    }
                }
            }

            return true;
        }


        public static IEnumerable<Patient> GetItems()
        {
            var itemCollection = new List<Patient>();

            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Patient_OpenList", db) { CommandType = CommandType.StoredProcedure })
                {

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var item = new Patient
                            {
                                Id            = reader.GetInt32From("Id"),
                                Lastname      = reader.GetStringFrom("Lastname"),
                                Firstname     = reader.GetStringFrom("Firstname"),
                                Middlename    = reader.GetStringFrom("Middlename"),
                                NameExtension = reader.GetStringFrom("NameExtension"),
                                Gender        = reader.GetStringFrom("Gender"),
                                BirthDate     = reader.GetDateTimeFrom("BirthDate"),
                                Department    = reader.GetStringFrom("Department"),
                                BloodType     = reader.GetStringFrom("BloodType"),
                                Height        = reader.GetDecimalFrom("Height"),
                                Weight        = reader.GetDecimalFrom("Weight"),
                                Remarks       = reader.GetStringFrom("Remarks")
                            };

                            item.RecordInfo.LoadValuesFrom(reader);
                            //item.RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                            //item.RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                            //item.RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                            //item.RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");

                            itemCollection.Add(item);
                        }
                    }
                }
            }

            return itemCollection;
        }

        public static void DeleteAll()
        {
            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Delete from Patient", db))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static IEnumerable<PatientSearchResult> SearchByName(string name)
        {
            var itemCollection = new List<PatientSearchResult>();

            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Patient_Search", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@Criteria", SqlDbType.NVarChar, 100).Value = name;

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var item = new PatientSearchResult
                            {
                                Id            = reader.GetInt32From("Id"),
                                Lastname      = reader.GetStringFrom("Lastname"),
                                Firstname     = reader.GetStringFrom("Firstname"),
                                Middlename    = reader.GetStringFrom("Middlename"),
                                NameExtension = reader.GetStringFrom("NameExtension"),
                                Gender        = reader.GetStringFrom("Gender"),
                                //BirthDate     = reader.GetDateTimeFrom("BirthDate"),
                            };
                            itemCollection.Add(item);
                        }
                    }
                }
            }

            return itemCollection;
        }

        public void LoadTreatmentHistory()
        {
            TreatmentHistoryItems.Clear();

            using (var db = SqlServer.CreateAndOpenConnection())
            {
                using (var cmd = new SqlCommand("Treatment_Open", db) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.Add("@PatientId", SqlDbType.Int).Value = Id;

                    using (var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var item = new TreatmentHistory();

                            item.Id                      = reader.GetInt32From("Id");
                            item.DateTreated             = reader.GetDateTimeFrom("DateTreated");
                            item.PatientId               = reader.GetInt32From("PatientId");
                            item.Condition               = reader.GetStringFrom("Condition");
                            item.Treatment               = reader.GetStringFrom("Treatment");
                            item.RecordInfo.CreatedDate  = reader.GetDateTimeFrom("Created");
                            item.RecordInfo.ModifiedDate = reader.GetDateTimeFrom("Modified");
                            item.RecordInfo.CreatedBy    = reader.GetStringFrom("CreatedBy");
                            item.RecordInfo.ModifiedBy   = reader.GetStringFrom("ModifiedBy");

                            TreatmentHistoryItems.Add(item);
                        }
                    }
                }
            }

        }
    }
}
