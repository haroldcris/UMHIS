using System;

namespace Umhis
{
    public class PatientSearchResult
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string NameExtension { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public string Fullname => $"{Lastname} , {Firstname} {Middlename}{(NameExtension.Length == 0 ? "" : ", " + NameExtension)}";
    }
}
