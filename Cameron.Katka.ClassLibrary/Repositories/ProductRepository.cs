using Cameron.Katka.ClassLibrary.Contexts;
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDbContext _context;

        public ProductRepository(IProductDbContext context)
        {
            _context = context;
        }

        public List<Product> FindAllProducts()
        {
            List<Product> products = _context.ProductsQueryable.ToList();

            return products;
        }

        public Product FindProduct(string skuSearch)
        {
            Product? product = _context.ProductsQueryable.FirstOrDefault(a => a.SKU == skuSearch);

            if (product == null)
            {
                return null;
            }

            return product;
        }
    }
}
