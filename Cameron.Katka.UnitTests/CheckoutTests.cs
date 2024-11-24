using Cameron.Katka.ClassLibrary.Dto;
using Cameron.Katka.ClassLibrary.Extensions;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.UnitTests
{
    internal class CheckoutTests
    {
        private IProductRepository _productRepository;
        private IServiceCollection _serviceCollection;
        private ICheckoutService _checkoutService;
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
                _checkoutService = scope.ServiceProvider.GetRequiredService<ICheckoutService>();
                _basketRepository = scope.ServiceProvider.GetRequiredService<IBasketRepository>();
                _productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            }
        }

        [Test]
        public void Scan_Should_Add_Products_To_Basket()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            List<Product> retrieveBasket = _basketRepository.GetAllProductsFromBasket();
            Assert.That(retrieveBasket.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetTotalPrice_Should_Return_Integer_Value()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            int totalPrice = _checkoutService.GetTotalPrice();

            Assert.IsInstanceOf<int>(totalPrice, "The total price should be an integer.");
        }

        [Test]
        public void UpdatePricingRules_Should_Apply_Correct_Discounts()
        {
            List<PricingRule> rules = new List<PricingRule>();
            PricingRule newRule = new PricingRule("A", 20);
            PricingRule newRule2 = new PricingRule("A", 30);
            PricingRule newRule3 = new PricingRule("E", 80, 3, 130);

            rules.Add(newRule);
            rules.Add(newRule2);
            rules.Add(newRule3);

            _productService.UpdatePricingRules(rules);

            _checkoutService.Scan("A");
            _checkoutService.Scan("E");
            _checkoutService.Scan("E");
            _checkoutService.Scan("E");

            int totalPrice = _checkoutService.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(160));
        }

        [Test]
        public void CalculateTotal_Should_Handle_Discounted_And_Remaining_Products()
        {
            List<PricingRule> rules = new List<PricingRule>();
            PricingRule newRule = new PricingRule("A", 70, 3, 130);
            rules.Add(newRule);

            _productService.UpdatePricingRules(rules);

            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");

            List<Product> retrieveBasket = _productRepository.FindAllProducts();

            int totalPrice = _checkoutService.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(200));
        }

        [Test]
        public void Scan_Should_Throw_Exception_For_NonExistent_SKU()
        {
            string invalidSku = "InvalidSKU";

            Assert.Throws<ArgumentNullException>(() => _checkoutService.Scan(invalidSku));
        }

        [Test]
        public void Scan_Should_Calculate_Correct_Price_Any_Order()
        {
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            int totalPrice = _checkoutService.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(95));
        }

        [Test]
        public void Scan_Should_Calculate_Correct_Price_Any_Bulk_Order()
        {
            List<PricingRule> rules = new List<PricingRule>();
            PricingRule newRule = new PricingRule("A", 70, 3, 130);
            PricingRule newRule2 = new PricingRule("Z", 70, 2, 40);
            PricingRule newRule3 = new PricingRule("C", 70, 1, 130);
            PricingRule newRule4 = new PricingRule("X", 70, 1, 800);
            rules.Add(newRule);
            rules.Add(newRule2);
            rules.Add(newRule3);
            rules.Add(newRule4);

            _productService.UpdatePricingRules(rules);

            _checkoutService.Scan("A");
            _checkoutService.Scan("B");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("Z");
            _checkoutService.Scan("X");
            _checkoutService.Scan("C");
            _checkoutService.Scan("C");
            _checkoutService.Scan("B");

            int totalPrice = _checkoutService.GetTotalPrice();
            Assert.That(totalPrice, Is.EqualTo(1375));
        }


    }
}
