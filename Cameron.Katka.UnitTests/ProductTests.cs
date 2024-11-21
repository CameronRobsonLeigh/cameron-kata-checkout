using Cameron.Katka.ClassLibrary.Contexts;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Repositories;

namespace Cameron.Katka.UnitTests
{
    internal class ProductTests
    {
        private IProductRepository _productRepository;
        private IProductDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new ProductDbContext();
            _productRepository = new ProductRepository(_context);
        }

        // Basic product test, kept this in a seperate set of tests in case we ever need to ammend the original structure
        [Test]
        public void Product_Should_Have_Required_Data()
        {
            Product product = _productRepository.FindProduct("A");       

            Assert.IsInstanceOf<string>(product.SKU);
            Assert.IsInstanceOf<decimal>(product.UnitPrice);
            if (product is SpecialProduct specialProduct)
            {
                Assert.IsInstanceOf<int>(specialProduct.DiscountUnits);
                Assert.IsInstanceOf<decimal>(specialProduct.DiscountUnitPrice);
            }
        }

        // Not a requirement for the task, but just showing capability of repositories and adhering to Single Responsibility
        [Test]
        public void Check_All_Products_Repository()
        {
            var products = _productRepository.FindAllProducts();

            Assert.IsNotNull(products, "The product list should not be null.");
        }

    }
}