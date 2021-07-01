namespace Components.User.Persistance.UnitOfWork
{
    using Components.Core.DataAccess.Base.Interfaces;
    using Components.User.Persistance.Poco;
    using Components.User.Persistance.Repository;

    internal interface IUserUnitOfWork : IUnitOfWork<User>
    {
        IUserRepository Repository { get; }
    }
}
