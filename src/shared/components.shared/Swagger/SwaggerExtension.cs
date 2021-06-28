namespace Components.Shared.Swagger
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerComponent(this IServiceCollection services)
        {
            services.AddSwaggerGen();   // Register the Swagger generator, defining 1 or more Swagger documents.

            return services;
        }

        public static IApplicationBuilder UseSwaggerComponent(this IApplicationBuilder app)
        {
            app.UseSwagger();           // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwaggerUI(setup =>   // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "ConsoleApp V1");
                setup.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}
