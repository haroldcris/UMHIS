namespace Umhis.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public EntityRecordInfo RecordInfo { get; set; }


        public BaseEntity()
        {
            RecordInfo = new EntityRecordInfo();
        }

    }
}
