namespace Umhis.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public EntityRecordInfo RecordInfo { get;  }


        protected BaseEntity()
        {
            RecordInfo = new EntityRecordInfo();
        }

    }
}
