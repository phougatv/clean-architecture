namespace Components.Shared.DataAccess.Base.Interfaces
{
    using Components.Shared.DataAccess.Base.Poco;
    using System.Threading.Tasks;

    public interface IAsyncUnitOfWork<TEntity>
        where TEntity : Entity
    {
        Task<int> CommitAsync();
    }
}
