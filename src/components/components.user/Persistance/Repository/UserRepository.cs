namespace Components.User.Persistance.Repository
{
    using Components.Core.DataAccess.Base.Interfaces;
    using Components.Core.DataAccess.Extensions;
    using Components.User.Persistance.Poco;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class UserRepository : IUserRepository
    {
        #region Private Fields
        // To detect redundant calls
        private bool _disposed = false;
        private readonly IUnitOfWorkWithDbContext<UserDbContext, User> _uow;
        #endregion Private Fields

        public UserRepository(IUnitOfWorkWithDbContext<UserDbContext, User> uow)
        {
            _uow = uow;
        }

        bool IRepository<User>.Create(User user)
        {
            var userEntry = _uow.DbContext.Users.Add(user);

            return userEntry.IsAdded();
        }
        bool IRepository<User>.Delete(Guid id)
        {
            var existingUser = InternalGet(id);

            return InternalDelete(existingUser);
        }
        bool IRepository<User>.Delete(User user) => InternalDelete(user);
        User IRepository<User>.Get(Guid id) => InternalGet(id);
        IEnumerable<User> IRepository<User>.GetAll() => _uow.DbContext.Set<User>();
        bool IRepository<User>.Update(User user)
        {
            _uow.DbContext.Entry(user).SetStateToModified();
            _uow.DbContext.Set<User>().Attach(user);

            return true;
        }

        #region Private Methods
        private bool InternalDelete(User user)
        {
            if (null == user)
                return false;

            var userEntity = _uow.DbContext.Set<User>().Remove(user);
            return userEntity.IsDeleted();
        }
        private User InternalGet(Guid id) => _uow.DbContext.Set<User>().FirstOrDefault(user => user.Id == id);
        #endregion

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
