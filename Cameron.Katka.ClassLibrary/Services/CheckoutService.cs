using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService : ICheckoutService
    {
        public IProductRepository _productRepository;
        public IBasketDbContext _basketContext;
        public IBasketRepository _basketRepository;
        public ICalculationService _calculationService;

        public CheckoutService(IProductRepository productRepository, IBasketDbContext basketContext, IBasketRepository basketRepository, ICalculationService calculationService)
        {
            _productRepository = productRepository;
            _basketContext = basketContext;
            _basketRepository = basketRepository;
            _calculationService = calculationService;
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
            List<Product> products = _basketRepository.GetAllStandardProductsScanned();
            int totalProductsPrice = _calculationService.CalculateStandardProducts(products);

            List<SpecialProduct> discountedProducts = _basketRepository.GetAllDiscountedProductsScanned();
            int totalDiscountedProductsPrice = _calculationService.CalculateDiscountedProducts(discountedProducts);

            return totalProductsPrice + totalDiscountedProductsPrice;
        }
    }
}
