namespace Components.Value.Business
{
    using Components.Value.Business.Models;
    using System;

    public interface IValueBusiness
    {
        ValueModel Get(Guid id);
    }
}
