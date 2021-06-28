namespace Components.User
{
    using Components.Shared.DataAccess.Base.Interfaces;
    using Components.User.Automapper.Profiles;
    using Components.User.Business;
    using Components.User.Persistance;
    using Components.User.Persistance.Poco;
    using Components.User.Persistance.Repository;
    using Components.User.Persistance.UnitOfWork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class UserComponentExtension
    {
        public static IServiceCollection AddUserComponent(this IServiceCollection services)
        {
            services.AddInternalUserComponent();

            return services;
        }

        private static IServiceCollection AddInternalUserComponent(this IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Components.User;Trusted_Connection=True;");
            });

            services.AddAutoMapper(typeof(UserProfile));
            services.AddScoped<IUnitOfWorkWithDbContext<UserDbContext, User>, UserUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
