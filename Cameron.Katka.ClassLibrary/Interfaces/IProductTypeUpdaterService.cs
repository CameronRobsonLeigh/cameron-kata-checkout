
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductTypeUpdaterService
    {
        void ReplaceDiscountProductWithNormal(SpecialProduct findExistingProduct, Product newProduct);

        void ReplaceNormalProductWithDiscountProduct(Product findExistingProduct, SpecialProduct newProduct);

    }
}
