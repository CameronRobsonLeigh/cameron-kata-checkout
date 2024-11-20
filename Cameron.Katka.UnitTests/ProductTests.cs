using Cameron.Katka.ClassLibrary;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.UnitTests
{
    internal class ProductTests
    {
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize the ApplicationDbContext before each test
            _context = new ApplicationDbContext();
        }

        // Basic product test, kept this in a seperate set of tests in case we ever need to ammend the original structure
        [Test]
        public void Product_Should_Have_Required_Data()
        {
            Product product = _context.Products.First(a => a.SKU == "A");

            Assert.IsInstanceOf<string>(product.SKU);
            Assert.IsInstanceOf<decimal>(product.UnitPrice);
            if (product is SpecialProduct specialProduct)
            {
                Assert.IsInstanceOf<int>(specialProduct.DiscountUnits);
                Assert.IsInstanceOf<decimal>(specialProduct.DiscountUnitPrice);
            }
        }

    }
}