using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService : ICheckoutService
    {
        public IProductRepository _productRepository;
        public IBasketDbContext _basketContext;

        public CheckoutService(IProductRepository productRepository, IBasketDbContext basketContext)
        {
            _productRepository = productRepository;
            _basketContext = basketContext;
        }

        public void Scan(string sku)
        {
            Product? product = _productRepository.FindProduct(sku);

            if (sku == null)
                throw new ArgumentNullException(nameof(product));

            if (product.UnitPrice < 0)
                throw new ArgumentException("Product price cannot be negative", nameof(product.UnitPrice));

            _basketContext.Basket.Add(product);
        }

        public int GetTotalPrice()
        {

         
            return 0;
        }
    }
}
