using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class ProductService : IProductService
    {
        IProductDbContext _productContext;

        public ProductService(IProductDbContext productContext)
        {
            _productContext = productContext;           
        }

        public void UpdatePricingRules(List<PricingRule> pricingRules)
        {
            foreach (var rule in pricingRules)
            {
                var findExistingRule =_productContext.ProductList.Find(a => a.SKU == rule.Sku);

                if (findExistingRule != null)
                {
                    findExistingRule.UnitPrice = rule.UnitPrice;
                }
                else
                {
                    AddStandardProduct(rule);
                }
            }
        }

        public void AddStandardProduct(PricingRule rule)
        {
            var prod = new Product(rule.Sku, rule.UnitPrice);

            _productContext.ProductList.Add(prod);
        }
    }
}
