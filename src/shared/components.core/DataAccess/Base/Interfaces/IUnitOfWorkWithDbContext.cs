namespace Components.Core.DataAccess.Base.Interfaces
{
    using Components.Core.DataAccess.Base.Poco;
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IUnitOfWorkWithDbContext<TDbContext, TEntity> : IDisposable
        where TDbContext : DbContext
        where TEntity : Entity
    {
        TDbContext DbContext { get; }
    }
}
