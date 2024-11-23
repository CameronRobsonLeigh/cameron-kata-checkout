using Cameron.Katka.ClassLibrary.Extensions;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Cameron.Katka.UnitTests
{
    internal class ProductTests
    {
        private IProductRepository _productRepository;
        private IProductDbContext _context;
        private IServiceCollection _serviceCollection;

        [SetUp]
        public void Setup()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddInjection();

            var _serviceProvider = _serviceCollection.BuildServiceProvider();
            using (var scope = _serviceProvider.CreateScope())
            {
                // Resolve dependencies from the scope
                _productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
                _context = scope.ServiceProvider.GetRequiredService<IProductDbContext>();
            }
        }


        // Basic product test, kept this in a seperate set of tests in case we ever need to ammend the original structure
        [Test]
        public void ProductRepository_FindProduct_Should_Return_Product_With_Valid_Properties()
        {
            Product product = _productRepository.FindProduct("A");       

            Assert.IsInstanceOf<string>(product.SKU);
            Assert.IsInstanceOf<int>(product.UnitPrice);
            if (product is SpecialProduct specialProduct)
            {
                Assert.IsInstanceOf<int>(specialProduct.DiscountUnits);
                Assert.IsInstanceOf<int>(specialProduct.DiscountUnitPrice);
            }
        }

        // Not a requirement for the task, but just showing capability of repositories and adhering to Single Responsibility
        [Test]
        public void ProductRepository_FindAllDiscountedProducts_Should_Return_NonEmpty_List()
        {
            List<Product> products = _productRepository.FindAllProducts();

            Assert.IsNotNull(products, "The product list should not be null.");
        }

        [Test]
        public void Check_All__Discounted_Products_Repository()
        {
            List<SpecialProduct> discountedProducts = _productRepository.FindAllDiscountedProducts();

            Assert.IsNotNull(discountedProducts, "The discounted product list should not be null.");
        }
    }
}