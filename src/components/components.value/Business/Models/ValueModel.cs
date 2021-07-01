namespace Components.Value.Business.Models
{
    using Components.Core.Domain.Base;
    using System;

    public class ValueModel : EntityDomainModel
    {
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
