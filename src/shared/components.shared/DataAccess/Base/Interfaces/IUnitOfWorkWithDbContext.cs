namespace Components.Shared.DataAccess.Base.Interfaces
{
    using Components.Shared.DataAccess.Base.Poco;
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IUnitOfWorkWithDbContext<TDbContext, TEntity> : IDisposable
        where TDbContext : DbContext
        where TEntity : Entity
    {
        TDbContext DbContext { get; }
    }
}
