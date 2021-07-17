namespace Components.Value
{
    using Components.Value.Automapper.Profiles;
    using Components.Value.Business;
    using Components.Value.Persistence.Base;
    using Components.Value.Persistence.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class ValueComponentExtension
    {
        public static IServiceCollection AddValueComponent(this IServiceCollection services)
            => services.AddInternalValueComponent();

        private static IServiceCollection AddInternalValueComponent(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ValueProfile));

            services.AddScoped<ValueDbContext>();
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<IValueBusiness, ValueBusiness>();

            return services;
        }
    }
}
