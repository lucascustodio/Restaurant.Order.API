using Microsoft.Extensions.DependencyInjection;
using Restaurant.Order.Application.Services;
using Restaurant.Order.Application.Services.Interfaces;
using Restaurant.Order.Domain.Aggregates.MorningAggregate.Interface;
using Restaurant.Order.Domain.Aggregates.NightAggregate.Interface;
using Restaurant.Order.Domain.Aggregates.OrderAggregate.Interface;
using Restaurant.Order.Infra.Data.Model.Denormalized.Interface;
using Restaurant.Order.Infra.Data.Repositories;

namespace Restaurant.Order.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<INightService, NightService>();
            services.AddScoped<IMorningService, MorningService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDenormalizedRepository, MenuDenormalizedRepository>();
            services.AddScoped<IMorningRepository, MorningRepository>();
            services.AddScoped<INightRepository, NightRepository>();
            return services;
        }
    }
}
