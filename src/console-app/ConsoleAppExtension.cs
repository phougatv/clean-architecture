namespace ConsoleApp
{
    using Components.Shared.Swagger;
    using Components.User;
    using Components.Value;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    internal static class ConsoleAppExtension
    {
        #region Add Services to ConfigureServices Method.
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDotNetCoreServices();
            services.AddCrossCuttingComponents();
            services.AddBusinessComponents();

            return services;
        }

        private static IServiceCollection AddDotNetCoreServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers(mvcOptions =>
            {
                var inputFormattersCount = mvcOptions.InputFormatters.Count;
            });

            return services;
        }

        private static IServiceCollection AddCrossCuttingComponents(this IServiceCollection services)
        {
            services.AddSwaggerComponent();

            return services;
        }

        private static IServiceCollection AddBusinessComponents(this IServiceCollection services)
        {
            services.AddUserComponent();
            services.AddValueComponent();

            return services;
        }
        #endregion Add Services to ConfigureServices Method.

        #region Use Components here to configure the HTTP-Request Pipeline
        internal static IApplicationBuilder UseServices(this IApplicationBuilder app)
        {
            app.UseCustomComponents();
            app.UseDotNetCoreServices();

            return app;
        }

        private static IApplicationBuilder UseDotNetCoreServices(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

        private static IApplicationBuilder UseCustomComponents(this IApplicationBuilder app)
        {
            app.UseSwaggerComponent();

            return app;
        }
        #endregion
    }
}
