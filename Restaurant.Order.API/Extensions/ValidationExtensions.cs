using Microsoft.Extensions.DependencyInjection;
using Restaurant.Order.Application.Validators;

namespace Restaurant.Order.API.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderCommandValidator, CreateOrderCommandValidator>();
            return services;
        }
    }
}
