namespace Components.Core.DataAccess.Base.Interfaces
{
    using Components.Core.DataAccess.Base.Poco;
    using System.Threading.Tasks;

    public interface IAsyncUnitOfWork<TEntity>
        where TEntity : Entity
    {
        Task<int> CommitAsync();
    }
}
