using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CalculationService : ICalculationService
    {
        public int CalculateStandardProducts(List<Product> products)
        {
            int calculatePriceOfFilteredProducts = (int)products.Sum(p => p.UnitPrice);

            return calculatePriceOfFilteredProducts;
        }

        public int CalculateDiscountedProducts(List<SpecialProduct> products)
        {
            int calculatePriceOfFilteredProducts = (int)products.Sum(p => p.UnitPrice);

            return calculatePriceOfFilteredProducts;
        }
    }
}
