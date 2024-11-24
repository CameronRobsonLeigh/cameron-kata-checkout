using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class ProductService : IProductService
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
                var findExistingProduct = _productContext.ProductList.Find(a => a.SKU == rule.Sku);

                if (findExistingProduct != null)
                {
                    if (findExistingProduct is SpecialProduct)
                    {
                        UpdateDiscountProduct(rule, (SpecialProduct)findExistingProduct);
                    }
                    else
                    {
                        UpdateStandardProduct(rule, findExistingProduct);
                    }
                }
                else
                {
                    if (rule.DiscountRate == null || rule.DiscountUnits == null)
                    {
                        AddStandardProduct(rule);
                    }
                    else
                    {
                        AddDiscountProduct(rule);
                    }

                }
            }
        }

        // If new product but no rate
        private void AddStandardProduct(PricingRule rule)
        {
            Product prod = new Product(rule.Sku, rule.UnitPrice);

            _productContext.ProductList.Add(prod);
        }

        // if new product but there is a rate
        private void AddDiscountProduct(PricingRule rule)
        {
            SpecialProduct prod = new SpecialProduct(rule.Sku, rule.UnitPrice, rule.DiscountUnits, rule.DiscountRate);

            _productContext.ProductList.Add(prod);
        }

        // if existing product that is standard (non-discount)
        private void UpdateStandardProduct(PricingRule rule, Product existingProduct)
        {
            if (rule.DiscountRate != null)
            {
                var newProduct = new SpecialProduct(existingProduct.SKU, rule.UnitPrice, rule.DiscountUnits, rule.DiscountRate);

                ReplaceNormalProductWithDiscountProduct(existingProduct, newProduct);
            }
            else
            {
                existingProduct.UnitPrice = rule.UnitPrice;
            }
        }

        // If existing product that is Discount product
        private void UpdateDiscountProduct(PricingRule rule, SpecialProduct findExistingProduct)
        {
            if (rule.DiscountRate == null || rule.DiscountUnits == null)
            {
                // cannot change type of product in memory so have to re-add
                var newProduct = new Product(findExistingProduct.SKU, rule.UnitPrice);

                ReplaceDiscountProductWithNormal(findExistingProduct, newProduct);
            }
            else
            {
                findExistingProduct.DiscountUnitPrice = rule.DiscountRate;
                findExistingProduct.DiscountUnits = rule.DiscountUnits;
                findExistingProduct.UnitPrice = rule.UnitPrice;

            }
        }

        // If Discount product initially, but we want to remove the discount this replaces
        private void ReplaceDiscountProductWithNormal(SpecialProduct findExistingProduct, Product newProduct)
        {
            _productContext.ProductList.Remove(findExistingProduct);

            _productContext.ProductList.Add(newProduct);
        }

        // If Standard Product initially, but we want to update to have a discount
        private void ReplaceNormalProductWithDiscountProduct(Product findExistingProduct, SpecialProduct newProduct)
        {
            _productContext.ProductList.Remove(findExistingProduct);

            _productContext.ProductList.Add(newProduct);
        }
    }
}
