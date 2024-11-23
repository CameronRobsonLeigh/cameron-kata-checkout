using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface ICalculationService
    {
        int CalculateStandardProducts(List<Product> products);

        int CalculateDiscountedProducts(List<SpecialProduct> products);
    }
}
