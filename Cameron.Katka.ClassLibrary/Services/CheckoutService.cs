﻿using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class CheckoutService : ICheckoutService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketDbContext _basketContext;
        private readonly IBasketRepository _basketRepository;
        private readonly ICalculationService _calculationService;

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

            if (product == null)
            {
                throw new ArgumentNullException($"The scanned SKU '{sku}' does not exist.");
            }

            if (product.UnitPrice < 0)
                throw new ArgumentException("Product price cannot be negative", nameof(product.UnitPrice));

            _basketContext.Basket.Add(product);
        }

        public int GetTotalPrice()
        {
            int totalProductsPrice = 0;
            int totalDiscountedProductsPrice = 0;

            List<Product> products = _basketRepository.GetAllStandardProductsScanned();
            if (products.Count > 0)
            {               
                totalProductsPrice = _calculationService.CalculateStandardProducts(products);
            }

            List<SpecialProduct> discountedProducts = _basketRepository.GetAllDiscountedProductsScanned();
            if (discountedProducts.Count > 0)
            {
                totalDiscountedProductsPrice = _calculationService.CalculateDiscountedProducts(discountedProducts);
            }

            return totalProductsPrice + totalDiscountedProductsPrice;
        }
    }
}
