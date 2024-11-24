
using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class ProductUpdaterService : IProductUpdaterService
    {
        IProductTypeUpdaterService _productTypeUpdaterService;

        public ProductUpdaterService(IProductTypeUpdaterService productTypeUpdaterService)
        {
            _productTypeUpdaterService = productTypeUpdaterService;
        }


        // if existing product that is standard (non-discount)
        public void UpdateStandardProduct(PricingRule rule, Product existingProduct)
        {
            if (rule.DiscountRate != null)
            {
                var newProduct = new SpecialProduct(existingProduct.SKU, rule.UnitPrice, rule.DiscountUnits, rule.DiscountRate);

                _productTypeUpdaterService.ReplaceNormalProductWithDiscountProduct(existingProduct, newProduct);
            }
            else
            {
                existingProduct.UnitPrice = rule.UnitPrice;
            }
        }

        // If existing product that is Discount product
        public void UpdateDiscountProduct(PricingRule rule, SpecialProduct findExistingProduct)
        {
            if (rule.DiscountRate == null || rule.DiscountUnits == null)
            {
                // cannot change type of product in memory so have to re-add
                var newProduct = new Product(findExistingProduct.SKU, rule.UnitPrice);

                _productTypeUpdaterService.ReplaceDiscountProductWithNormal(findExistingProduct, newProduct);
            }
            else
            {
                findExistingProduct.DiscountUnitPrice = rule.DiscountRate;
                findExistingProduct.DiscountUnits = rule.DiscountUnits;
                findExistingProduct.UnitPrice = rule.UnitPrice;

            }
        }
    }
}
