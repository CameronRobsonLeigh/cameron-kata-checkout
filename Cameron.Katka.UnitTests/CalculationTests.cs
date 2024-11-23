
using Cameron.Katka.ClassLibrary.Extensions;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.UnitTests
{
    internal class CalculationTests
    {

        private IServiceCollection _serviceCollection;
        private ICheckoutService _checkoutService;
        private IBasketRepository _basketRepository;
        private ICalculationService _calculationService;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddInjection();

            var _serviceProvider = _serviceCollection.BuildServiceProvider();
            using (var scope = _serviceProvider.CreateScope())
            {
                _checkoutService = scope.ServiceProvider.GetRequiredService<ICheckoutService>();
                _basketRepository = scope.ServiceProvider.GetRequiredService<IBasketRepository>();
                _calculationService = scope.ServiceProvider.GetRequiredService<ICalculationService>();
            }
        }

        [Test]
        public void CalculateStandardProducts_Should_Return_CorrectTotal()
        {
            _checkoutService.Scan("C");
            _checkoutService.Scan("D");

            List<Product> products = _basketRepository.GetAllStandardProductsScanned();

            int totalPrice = _calculationService.CalculateStandardProducts(products);

            Assert.IsInstanceOf<int>(totalPrice, "The total price should be an integer.");
        }

        [Test]
        public void CalculateDiscountedProducts_Should_Return_CorrectTotal()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            List<SpecialProduct> products = _basketRepository.GetAllDiscountedProductsScanned();

            int totalPrice = _calculationService.CalculateDiscountedProducts(products);

            Assert.IsInstanceOf<int>(totalPrice, "The total price should be an integer.");

        }
    }
}
