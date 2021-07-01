namespace Components.Core.Domain.Base
{
    using System;

    public class EntityDomainModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
