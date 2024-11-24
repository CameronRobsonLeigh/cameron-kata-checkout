using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductDbContext _productContext;
        private readonly IProductAdderService _productAdderService;
        private readonly IProductTypeUpdaterService _productTypeUpdaterService;
        private readonly IProductUpdaterService _productUpdaterService;

        public ProductService(IProductDbContext productContext, IProductAdderService productAdderService, IProductTypeUpdaterService productTypeUpdaterService, IProductUpdaterService productUpdaterService)
        {
            _productContext = productContext;
            _productAdderService = productAdderService;
            _productTypeUpdaterService = productTypeUpdaterService;
            _productUpdaterService = productUpdaterService;
        }

        public void UpdatePricingRules(List<PricingRule> pricingRules)
        {
            foreach (var rule in pricingRules)
            {
                var findExistingProduct = _productContext.ProductList.Find(a => a.SKU == rule.Sku);

                if (findExistingProduct != null)
                {
                    if (findExistingProduct is SpecialProduct)
                    {
                        _productUpdaterService.UpdateDiscountProduct(rule, (SpecialProduct)findExistingProduct);
                    }
                    else
                    {
                        _productUpdaterService.UpdateStandardProduct(rule, findExistingProduct);
                    }
                }
                else
                {
                    if (rule.DiscountRate == null || rule.DiscountUnits == null)
                    {
                        _productAdderService.AddStandardProduct(rule);
                    }
                    else
                    {
                        _productAdderService.AddDiscountProduct(rule);
                    }
                }
            }
        }
    }
}
