namespace Components.Core.DataAccess.Base.Interfaces
{
    using Components.Core.DataAccess.Base.Poco;
    using System;

    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : Entity
    {
        int Commit();
    }
}
