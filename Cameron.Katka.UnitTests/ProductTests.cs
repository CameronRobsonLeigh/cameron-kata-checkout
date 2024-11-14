using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.UnitTests
{
    internal class ProductTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Basic product test, kept this in a seperate set of tests in case we ever need to ammend the original structure
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