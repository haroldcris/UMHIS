using Bogus;
using Bogus.DataSets;
using System;
using System.Data.SqlClient;
using System.IO;
using Umhis.Core;
using Umhis.Core.Database;

namespace SampleDataGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            SqlServer.ConnectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "(localdb)\\mssqllocaldb",
                AttachDBFilename = "D:\\GitRepos\\OLFU\\medical-history-information-system\\data\\database.mdf",
                //AttachDBFilename = "|DataDirectory|\\Data\\database.mdf",
                IntegratedSecurity = true,
            };


            //Set the randomizer seed if you wish to generate repeatable data sets.
            //Randomizer.Seed = new Random(867530949);


            CreatePatientRecord();

            //var user = new UserAccount
            //{
            //    DisplayName = "Admin",
            //    Active = true,
            //    Username = "admin",
            //    Password = PasswordSecurity.CreateHash("admin"),
            //    SecurityLevel = "Admin"
            //};

            //user.Save("User");


            //var user = new UserAccount
            //{
            //    DisplayName = "User",
            //    Active = true,
            //    Username = "user1",
            //    Password = PasswordSecurity.CreateHash("user1"),
            //    SecurityLevel = "User"
            //};

            //user.Save("User");




            Console.WriteLine("Done.");
            Console.ReadLine();

        }

        static void CreatePatientRecord()
        {
            //Create new Patient
            var faker = new Faker();

            var genderList = new[] {"Male","Female"};

            var extension = new[] {"","","", "", "", "Jr.", "II", "III"};
            var department = new[]
            {
                    "Engineering",
                    "Education",
                    "Maritime Education",
                    "Criminal Justice",
                    "Arts & Sciences",
                    "Business and Accountancy",
                    "Computer Studies",
                    "Nursing"
            };

            var blood = new[] {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+" , "O-" };
            var idNum = 0;

            var diagnosis = GetDiagnosis();
            var treatment = GetTreatment();

            Console.WriteLine("Deleting All Record From DB....");
            Patient.DeleteAll();


            for (int counter = 0; counter < 200; counter++)
            {
                var gender =  faker.PickRandom(genderList);
                Console.WriteLine($"Generating Patient # {counter}  {gender}  ");

                idNum++;

                var num = faker.Random.Int(0, 99);
                var height = 1 + ((decimal)num / 100m);

                var p = new Patient()
                {
                    Lastname      = faker.Name.LastName(),
                    Firstname     = faker.Name.FirstName(gender == "Male" ? Name.Gender.Male : Name.Gender.Female),
                    Middlename    = faker.Name.LastName(),
                    NameExtension = faker.PickRandom(extension),

                    Department = faker.PickRandom(department),
                    Gender        = gender,
                    BloodType     = faker.PickRandom(blood),
                    Height        = height,
                    Weight        = faker.Random.Int(50,300),
                    BirthDate     = faker.Date.Between(new DateTime(1980, 1, 1), new DateTime(2000,12,30))
                };


                for (int i = 0; i < 20; i++)
                {
                    p.TreatmentHistoryItems.Add(new TreatmentHistory()
                    {
                        DateTreated = faker.Date.Between(new DateTime(2017, 1, 1), new DateTime(2019, 9, 30)),
                        Condition = faker.PickRandom(diagnosis).Trim(),
                        Treatment = faker.PickRandom(treatment).Trim()
                    });
                }

                p.Save("User");
            }

        }



        static string[] GetDiagnosis()
        {

            using (var reader = new StreamReader("diagnosis.txt"))
            {
                var str = reader.ReadToEnd();

                return str.Split('\n');
            }
        }


        static string[] GetTreatment()
        {

            using (var reader = new StreamReader("treatment.txt"))
            {
                var str = reader.ReadToEnd();

                return str.Split('\n');
            }
        }
    }
}