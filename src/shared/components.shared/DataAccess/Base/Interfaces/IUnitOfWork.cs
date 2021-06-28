namespace Components.Shared.DataAccess.Base.Interfaces
{
    using Components.Shared.DataAccess.Base.Poco;
    using System;

    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : Entity
    {
        int Commit();
    }
}
