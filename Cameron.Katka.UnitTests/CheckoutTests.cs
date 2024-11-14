using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Services;

namespace Cameron.Katka.UnitTests
{
    internal class CheckoutTests
    {
        private CheckoutService _checkoutService;

        [SetUp]
        public void Setup()
        {
            _checkoutService = new CheckoutService();
        }

        [Test]
        public void Product_Should_Scan()
        {
            Product product = new Product("A", 50.00m, 3, 130.00m);
            int productCount = _checkoutService.Scan(product);
            Assert.That(productCount, Is.EqualTo(1));
        }

        [Test]
        public void Scan_Product_Should_ThrowException_When_ProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _checkoutService.Scan(null));
        }

        [Test]
        public void Scan_Product_Should_Have_NegativePrice()
        {
            Product productWithNegativePrice = new Product("A", -50.00m, 3, 130.00m);
            Assert.Throws<ArgumentException>(() => _checkoutService.Scan(productWithNegativePrice), "Product price cannot be negative");
        }

        [Test]
        public void Scan_Multiple_Products_Should_Increase_Basket_Count()
        {
            Product product1 = new Product("A", 50.00m, 1, 40.00m);
            Product product2 = new Product("B", 30.00m, 2, 25.00m);

            _checkoutService.Scan(product1); 
            int countAfterFirstScan = _checkoutService.Scan(product2);

            Assert.That(countAfterFirstScan, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_Basic_Total_No_Discount()
        {
            Product prod = new Product("A", 50.00m, 1, 40.00m);

            int scanProd = _checkoutService.Scan(prod);
            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(50.00m));
        }

    }
}
