using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private List<Product> _products;

        public ApplicationDbContext()
        {
            _products = new List<Product>
            {
                new SpecialProduct("A", 50m, 3, 130m),
                new SpecialProduct("B", 30m, 2, 45m),
                new Product("C", 20m),
                new Product("D", 15m)
            };
        }

        public IQueryable<Product> ProductsQueryable => _products.AsQueryable();

        public List<Product> ProductList => _products;
    }
}
