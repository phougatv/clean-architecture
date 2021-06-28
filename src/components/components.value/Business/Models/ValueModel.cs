namespace Components.Value.Business.Models
{
    using Components.Shared.Domain.Base;
    using System;

    public class ValueModel : EntityModel
    {
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
