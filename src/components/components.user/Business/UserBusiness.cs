namespace Components.User.Business
{
    using AutoMapper;
    using Components.User.Business.Models;
    using Components.User.Persistance.Poco;
    using Components.User.Persistance.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class UserBusiness : IUserBusiness
    {
        #region Private Fields
        private readonly IMapper _mapper;
        private readonly IUserUnitOfWork _uow;
        private bool _disposed = false; // To detect redundant calls
        #endregion Private Fields

        public UserBusiness(
            IMapper mapper,
            IUserUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        bool IUserBusiness.Create(UserModel model)
        {
            var poco = _mapper.Map<User>(model);
            var result = _uow.Repository.Create(poco);
            var commit = _uow.Commit();
            return result && commit > 0;
        }
        bool IUserBusiness.Delete(Guid id)
        {
            var result = _uow.Repository.Delete(id);
            var commit = _uow.Commit();
            return result && commit > 0;
        }
        bool IUserBusiness.Delete(UserModel model)
        {
            var poco = _mapper.Map<User>(model);
            var result = _uow.Repository.Delete(poco);
            var commit = _uow.Commit();
            return result && commit > 0;
        }
        UserModel IUserBusiness.Get(Guid id)
        {
            var poco = _uow.Repository.Get(id);
            if (null == poco)
                return null;

            var model = _mapper.Map<UserModel>(poco);
            return model;
        }
        IEnumerable<UserModel> IUserBusiness.GetAll()
        {
            var pocos = _uow.Repository.GetAll().ToArray();
            if (null == pocos || !pocos.Any())
                return Array.Empty<UserModel>();

            var models = _mapper.Map<IEnumerable<UserModel>>(pocos);
            return models;
        }
        bool IUserBusiness.Update(UserModel model)
        {
            var user = _mapper.Map<User>(model);
            if (null == user)
                return false;

            var result = _uow.Repository.Update(user);
            var commit = _uow.Commit();
            return result && commit > 0;
        }

        #region Dispose
        /// <summary> Public implementation of Dispose pattern callable by consumers. </summary>
        public void Dispose()
        {
            Dispose(true);              // Dispose of unmanaged resources
            GC.SuppressFinalize(this);  // Suppress finalization
        }

        /// <summary> Protected implementation of Dispose pattern. </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                //TODO: dispose managed state (managed objects).
            }

            //TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            //TODO: set large fields to null.

            _disposed = true;
        }
        #endregion Dispose
    }
}
