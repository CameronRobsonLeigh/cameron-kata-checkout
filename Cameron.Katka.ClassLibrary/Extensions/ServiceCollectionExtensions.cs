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
            services.AddScoped<IProductDbContext, ProductContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IBasketDbContext, BasketContext>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductAdderService, ProductAdderService>();
            services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
            services.AddScoped<IProductTypeUpdaterService, ProductTypeUpdaterService>();
        }
    }
}
