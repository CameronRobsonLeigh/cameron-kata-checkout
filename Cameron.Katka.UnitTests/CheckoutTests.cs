﻿using Cameron.Katka.ClassLibrary.Extensions;
using Cameron.Katka.ClassLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.UnitTests
{
    internal class CheckoutTests
    {
        private IProductRepository _productRepository;
        private IProductDbContext _context;
        private IServiceCollection _serviceCollection;
        private ICheckoutService _checkoutService;
        private IBasketDbContext _basketDbContext;
        private IBasketRepository _basketRepository;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddInjection();

            var _serviceProvider = _serviceCollection.BuildServiceProvider();
            using (var scope = _serviceProvider.CreateScope())
            {
                _productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
                _context = scope.ServiceProvider.GetRequiredService<IProductDbContext>();
                _checkoutService = scope.ServiceProvider.GetRequiredService<ICheckoutService>();
                _basketDbContext = scope.ServiceProvider.GetRequiredService<IBasketDbContext>();
                _basketRepository = scope.ServiceProvider.GetRequiredService<IBasketRepository>();
            }
        }

        [Test]
        public void Product_Should_Scan()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            var retrieveBasket = _basketRepository.GetAllProductsFromBasket();
            Assert.IsNotNull(retrieveBasket);

        }
    }
}
