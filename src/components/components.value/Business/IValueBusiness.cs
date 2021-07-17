namespace Components.Value.Business
{
    using Components.Value.Business.Models;
    using System;

    public interface IValueBusiness
    {
        bool Create(ValueDomainModel model);
        ValueDomainModel Get(Guid id);
    }
}
