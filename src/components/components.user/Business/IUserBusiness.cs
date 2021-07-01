namespace Components.User.Business
{
    using Components.User.Business.Models;
    using System;
    using System.Collections.Generic;

    public interface IUserBusiness : IDisposable
    {
        bool Create(UserDomainModel model);
        bool Delete(Guid id);
        bool Delete(UserDomainModel model);
        UserDomainModel Get(Guid id);
        IEnumerable<UserDomainModel> GetAll();
        bool Update(UserDomainModel model);
    }
}
