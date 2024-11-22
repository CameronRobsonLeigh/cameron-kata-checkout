using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService : ICheckoutService
    {
        public IProductRepository _productRepository;
        private List<Product> _basket = new List<Product>();

        public CheckoutService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int Scan(string sku)
        {
            Product? product = _productRepository.FindProduct(sku);

            if (sku == null)
                throw new ArgumentNullException(nameof(product));

            if (product.UnitPrice < 0)
                throw new ArgumentException("Product price cannot be negative", nameof(product.UnitPrice));

            _basket.Add(product);

            return _basket.Count;
        }

        public decimal GetTotalPrice()
        {
         
            return 0;
        }
    }
}
