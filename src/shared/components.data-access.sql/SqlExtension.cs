namespace Components.DataAccess.Sql
{
    using Components.DataAccess.Sql.Accessors;
    using Components.DataAccess.Sql.Executioner;
    using Components.DataAccess.Sql.Persistence;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;

    public static class SqlExtension
    {
        public static IServiceCollection AddDataAccessSql(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConfiguration = configuration.GetSection("Shared:DataAccess:Sql").Get<SqlConfiguration>(binderOptions => { binderOptions.BindNonPublicProperties = true; });
            services.AddSingleton(sqlConfiguration);
            services.AddSingleton<IConnectionStringAccessor, ConnectionStringAccessor>();

            services.AddScoped<Queue<SqlCommandDetail>>();
            services.AddScoped<IExecutioner, SqlExecutioner>();
            services.AddScoped<IPersistent, SqlPersistent>();

            return services;
        }
    }
}
