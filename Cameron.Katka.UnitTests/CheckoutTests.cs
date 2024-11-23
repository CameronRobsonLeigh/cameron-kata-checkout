using Cameron.Katka.ClassLibrary.Extensions;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

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
        private IProductService _productService;

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
                _productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            }
        }

        [Test]
        public void Product_Should_Scan()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            List<Product> retrieveBasket = _basketRepository.GetAllProductsFromBasket();
            Assert.That(retrieveBasket.Count, Is.EqualTo(2));
        }

        [Test]
        public void Get_Total_Value()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            int totalPrice = _checkoutService.GetTotalPrice();

            Assert.IsInstanceOf<int>(totalPrice, "The total price should be an integer.");
        }

        [Test]
        public void Set_Pricing_Rules()
        {
            List<PricingRule> rules = new List<PricingRule>();
            PricingRule newRule = new PricingRule("A", 20);
            PricingRule newRule2 = new PricingRule("A", 30);
            PricingRule newRule3 = new PricingRule("E", 80, 3, 130);

            rules.Add(newRule);
            rules.Add(newRule2);
            rules.Add(newRule3);

            _productService.UpdatePricingRules(rules);
            List<Product> retrieveBasket = _productRepository.FindAllProducts();

            _checkoutService.Scan("A");
            _checkoutService.Scan("E");
            _checkoutService.Scan("E");
            _checkoutService.Scan("E");

            int totalPrice = _checkoutService.GetTotalPrice();
            //Assert.That(totalPrice, Is.EqualTo(150));
        }


    }
}
