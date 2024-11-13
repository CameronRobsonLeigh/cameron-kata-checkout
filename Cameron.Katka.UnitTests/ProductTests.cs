using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.UnitTests
{
    internal class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Product_Should_Have_Required_Data()
        {
            Product product = new Product("A", 50.00m, 3, 130.00m);
            Assert.IsInstanceOf<string>(product.SKU);
            Assert.IsInstanceOf<decimal>(product.UnitPrice);
            Assert.IsInstanceOf<int>(product.DiscountUnits);
            Assert.IsInstanceOf<decimal>(product.DiscountUnitPrice);
        }

    }
}