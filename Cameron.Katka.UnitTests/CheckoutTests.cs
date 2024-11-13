using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Services;

namespace Cameron.Katka.UnitTests
{
    internal class CheckoutTests
    {
        private CheckoutService _checkOutService;

        [SetUp]
        public void Setup()
        {
            _checkOutService = new CheckoutService();
        }

        [Test]
        public void Product_Should_Scan()
        {
            Product product = new Product("A", 50.00m, 3, 130.00m);
            int productCount = _checkOutService.Scan(product);
            Assert.AreEqual(1, productCount);

        }
    }
}
