using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class ProductAdderService : IProductAdderService
    {
        private readonly IProductDbContext _productContext;

        public ProductAdderService(IProductDbContext productContext)
        {
            _productContext = productContext;
        }


        // If new product but no rate
        public void AddStandardProduct(PricingRule rule)
        {
            Product prod = new Product(rule.Sku, rule.UnitPrice);

            _productContext.ProductList.Add(prod);
        }

        // if new product but there is a rate
        public void AddDiscountProduct(PricingRule rule)
        {
            SpecialProduct prod = new SpecialProduct(rule.Sku, rule.UnitPrice, rule.DiscountUnits, rule.DiscountRate);

            _productContext.ProductList.Add(prod);
        }

    }

}
