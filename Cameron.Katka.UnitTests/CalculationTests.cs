
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Repositories;
using Cameron.Katka.ClassLibrary.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.UnitTests
{
    internal class CalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Calculate_Normal_Products()
        {
            _checkoutService.Scan("A");
            _checkoutService.Scan("B");

            List<Product> products = _basketRepository.GetAllStandardProducts();

            int cost = _calculationService.CalculateNormalProducts(products);

            Assert.IsInstanceOf<int>(totalPrice, "The total price should be an integer.");
        }
    }
}
