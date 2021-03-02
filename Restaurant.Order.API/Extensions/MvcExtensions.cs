using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Order.API.Extensions
{
    public static class MvcExtensions
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services
                .AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
