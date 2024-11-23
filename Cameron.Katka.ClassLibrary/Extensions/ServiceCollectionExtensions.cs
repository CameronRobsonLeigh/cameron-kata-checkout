using Cameron.Katka.ClassLibrary.Contexts;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Repositories;
using Cameron.Katka.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.ClassLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductDbContext, ProductDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IBasketDbContext, BasketDbContext>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICalculationService, CalculationService>();
        }
    }
}
