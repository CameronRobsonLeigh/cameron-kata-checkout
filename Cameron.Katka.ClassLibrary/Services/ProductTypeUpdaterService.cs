using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    internal class ProductTypeUpdaterService : IProductTypeUpdaterService
    {
        private readonly IProductDbContext _productContext;
        public ProductTypeUpdaterService(IProductDbContext productContext)
        {
            _productContext = productContext;
        }

        // If Discount product initially, but we want to remove the discount this replaces
        public void ReplaceDiscountProductWithNormal(SpecialProduct findExistingProduct, Product newProduct)
        {
            _productContext.ProductList.Remove(findExistingProduct);

            _productContext.ProductList.Add(newProduct);
        }

        // If Standard Product initially, but we want to update to have a discount
        public void ReplaceNormalProductWithDiscountProduct(Product findExistingProduct, SpecialProduct newProduct)
        {
            _productContext.ProductList.Remove(findExistingProduct);

            _productContext.ProductList.Add(newProduct);
        }

    }
}
