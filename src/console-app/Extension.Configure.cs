namespace ConsoleApp
{
    using Components.Core.Swagger;
    using Microsoft.AspNetCore.Builder;

    internal static partial class Extension
    {
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
