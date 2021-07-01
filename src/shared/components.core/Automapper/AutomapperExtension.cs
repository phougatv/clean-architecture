namespace Components.Core.Automapper
{
    using Microsoft.Extensions.DependencyInjection;

    public static class AutomapperExtension
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
