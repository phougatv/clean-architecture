namespace Components.Shared.Automapper
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class AutomapperExtension
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
