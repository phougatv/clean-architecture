namespace Components.Core.DataAccess.Base.Poco
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
