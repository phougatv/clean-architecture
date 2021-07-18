namespace ConsoleApp
{
    using Components.Core.Swagger;
    using Components.DataAccess.Sql;
    using Components.User;
    using Components.Value;
    using ConsoleApp.Errors;
    using ConsoleApp.User.Automapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary> Adds services to the container </summary>
    internal static partial class Extension
    {
        #region Add Services to ConfigureServices Method.
        internal static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDotNetCoreServices();
            services.AddCrossCuttingComponents(configuration);
            services.AddBusinessComponents();

            return services;
        }

        private static IServiceCollection AddDotNetCoreServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers(mvcOptions =>
            {
                mvcOptions.Filters.Add(new ValidateModelActionFilter());
            });

            return services;
        }

        private static IServiceCollection AddCrossCuttingComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(UserViewModelProfile));
            services.AddSwaggerComponent();
            services.AddDataAccessSql(configuration);

            return services;
        }

        private static IServiceCollection AddBusinessComponents(this IServiceCollection services)
        {
            services.AddUserComponent();
            services.AddValueComponent();

            return services;
        }
        #endregion Add Services to ConfigureServices Method.
    }
}
