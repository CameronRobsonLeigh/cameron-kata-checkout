using Cameron.Katka.ClassLibrary.Models;

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
            _checkOutService.Scan(product);
            Assert.AreEqual(1, _checkOutService.productCount);

        }
    }
}
