namespace Components.Core.DataAccess.Base.Poco
{
    using Components.DataAccess.Sql.Attributes;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Entity
    {
        [Key]
        [PropertyParameterBinder("@Id")]
        public Guid Id { get; set; }

        [PropertyParameterBinder("@CreatedBy")]
        public Guid CreatedBy { get; set; }

        [PropertyParameterBinder("@UpdatedBy")]
        public Guid? UpdatedBy { get; set; }

        [PropertyParameterBinder("@CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [PropertyParameterBinder("@UpdatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}
