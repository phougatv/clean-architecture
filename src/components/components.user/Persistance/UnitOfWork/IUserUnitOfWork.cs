namespace Components.User.Persistance.UnitOfWork
{
    using Components.Shared.DataAccess.Base.Interfaces;
    using Components.User.Persistance.Poco;
    using Components.User.Persistance.Repository;

    internal interface IUserUnitOfWork : IUnitOfWork<User>
    {
        IUserRepository Repository { get; }
    }
}
