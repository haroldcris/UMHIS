using Bogus;
using Bogus.DataSets;
using System;
using System.Data.SqlClient;
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
            Randomizer.Seed = new Random(867530949);



            //Create new Patient
            var faker = new Faker();

            var genderList = new[] {"Male","Female"};

            var extension = new[] {"","","", "Sr.", "Jr.", "II", "III", "IV", "V", "VI" };
            var blood = new[] {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+" , "O-" };
            var idNum = 0;


            Console.WriteLine("Deleting All Record From DB....");
            Patient.DeleteAll();


            for (int counter = 0; counter < 200; counter++)
            {
                var gender =  faker.PickRandom(genderList);
                Console.WriteLine($"Generating Patient # {counter}  {gender}  ");

                idNum++;
                var p = new Patient()
                {
                    Lastname      = faker.Name.LastName(),
                    Firstname     = faker.Name.FirstName(gender == "Male" ? Name.Gender.Male : Name.Gender.Female),
                    Middlename    = faker.Name.LastName(),
                    NameExtension = faker.PickRandom(extension),

                    Gender        = gender,
                    BloodType     = faker.PickRandom(blood),
                    Height        = faker.Random.Decimal(1m, 1.5m),

                    BirthDate     = faker.Date.Between(new DateTime(1980, 1, 1), new DateTime(2000,12,30))
                };

                p.Save("User");
            }


            Console.WriteLine("Done.");
            Console.ReadLine();

        }
    }
}