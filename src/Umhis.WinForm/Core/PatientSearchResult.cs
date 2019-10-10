using System;

namespace Umhis.Core
{
    public class PatientSearchResult
    {
        public int Id { get; set; }
        public string Lastname { private get; set; }
        public string Firstname { private get; set; }
        public string Middlename { private get; set; }
        public string NameExtension { private get; set; }

        public string Gender { get; set; }

        public string Fullname => $"{Lastname} , {Firstname} {Middlename}{(NameExtension.Length == 0 ? "" : ", " + NameExtension)}";
    }
}
