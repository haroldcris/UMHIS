using System;
using System.Data;
using Umhis.Core.Database;

namespace Umhis.Core
{
    public class EntityRecordInfo
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


        public void LoadValuesFrom(IDataReader reader)
        {
            CreatedBy = reader.GetStringFrom("CreatedBy");
            ModifiedBy = reader.GetStringFrom("ModifiedBy");

            CreatedDate = reader.GetDateTimeFrom("Created");
            ModifiedDate = reader.GetDateTimeFrom("Modified");

        }
    }
}
