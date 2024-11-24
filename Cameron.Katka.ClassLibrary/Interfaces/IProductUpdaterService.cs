using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductUpdaterService
    {
        void UpdateStandardProduct(PricingRule rule, Product existingProduct);

        void UpdateDiscountProduct(PricingRule rule, SpecialProduct findExistingProduct);

    }
}
