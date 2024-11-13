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
            Assert.AreEqual(1, productCount);
        }

        [Test]
        public void ScanProduct_Should_ThrowException_When_ProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _checkoutService.Scan(null));
        }

    }
}
