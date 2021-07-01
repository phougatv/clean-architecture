namespace Components.Core.DataAccess.Base.Interfaces
{
    using Components.Core.DataAccess.Base.Poco;
    using System;
    using System.Collections.Generic;

    public interface IRepository<TEntity> : IDisposable
        where TEntity : Entity
    {
        bool Create(TEntity entity);
        bool Delete(Guid id);
        bool Delete(TEntity entity);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity entity);

    }
}
