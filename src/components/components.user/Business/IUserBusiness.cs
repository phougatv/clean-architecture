namespace Components.User.Business
{
    using Components.User.Business.Models;
    using System;
    using System.Collections.Generic;

    public interface IUserBusiness : IDisposable
    {
        bool Create(UserModel model);
        bool Delete(Guid id);
        bool Delete(UserModel model);
        UserModel Get(Guid id);
        IEnumerable<UserModel> GetAll();
        bool Update(UserModel model);
    }
}
