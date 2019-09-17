using System;

namespace Umhis.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public Guid RowId { get; set; }

        public EntityRecordInfo RecordInfo { get; set; }

        public EntityRecordStatus RecordStatus { get; set; }

        public BaseEntity(EntityRecordStatus status)
        {
            RowId = Guid.NewGuid();
            RecordStatus = status;
            RecordInfo = new EntityRecordInfo();
        }

    }
}
