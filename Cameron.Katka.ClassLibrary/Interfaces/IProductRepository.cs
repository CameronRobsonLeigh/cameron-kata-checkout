using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductRepository
    {
        List<Product> FindAllProducts();

        Product FindProduct(string skuSearch);

        List<SpecialProduct> FindAllDiscountedProducts();
    }
}