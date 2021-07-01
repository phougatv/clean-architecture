namespace Components.User.Persistance.UnitOfWork
{
    using Components.Core.DataAccess.Base.Interfaces;
    using Components.User.Persistance.Poco;
    using Components.User.Persistance.Repository;
    using System;

    internal class UserUnitOfWork : IUserUnitOfWork, IUnitOfWorkWithDbContext<UserDbContext, User>
    {
        #region Private Fields
        private readonly IServiceProvider _serviceProvider;
        private bool _disposed = false; // To detect redundant calls
        #endregion Private Fields

        #region Properties
        /// <summary> Gets the UserDbContext instance. </summary>
        public UserDbContext DbContext { get; }

        /// <summary> Gets the IUserRepository instance. </summary>
        IUserRepository IUserUnitOfWork.Repository => (IUserRepository)InternalGetService(typeof(IUserRepository));
        #endregion Properties

        #region Constructor
        public UserUnitOfWork(
            IServiceProvider serviceProvider,
            UserDbContext dbContext)
        {
            DbContext = dbContext;
            _serviceProvider = serviceProvider;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary> Commits the changes in the DB. </summary>
        /// <returns></returns>
        int IUnitOfWork<User>.Commit() => DbContext.SaveChanges();
        #endregion Public Methods

        #region Private Methods
        private object InternalGetService(Type type) => _serviceProvider.GetService(type);
        #endregion Private Methods

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
    }
}
