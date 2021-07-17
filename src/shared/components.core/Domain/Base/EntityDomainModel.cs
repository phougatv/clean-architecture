namespace Components.Core.Domain.Base
{
    using System;

    public class EntityDomainModel
    {
        private Guid _id;
        private DateTime _createdOn;

        public Guid Id
        {
            get
            {
                if (Guid.Empty == _id)
                    _id = Guid.NewGuid();
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime CreatedOn
        {
            get
            {
                if (DateTime.MinValue == _createdOn)
                    _createdOn = DateTime.UtcNow;
                return _createdOn;
            }
            set
            {
                _createdOn = value;
            }
        }
        public DateTime? UpdatedOn { get; set; }
    }
}
