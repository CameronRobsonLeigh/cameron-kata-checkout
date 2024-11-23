using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Contexts
{
    internal class ProductContext : IProductDbContext
    {
        private List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>
            {
                new SpecialProduct("A", 50, 3, 130),
                new SpecialProduct("B", 30, 2, 45),
                new Product("C", 20),
                new Product("D", 15)
            };
        }

        public IQueryable<Product> ProductsQueryable => _products.AsQueryable();

        public List<Product> ProductList => _products;
    }
}
