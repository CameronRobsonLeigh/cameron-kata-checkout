using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductAdderService
    {
        void AddStandardProduct(PricingRule rule);

        void AddDiscountProduct(PricingRule rule);

    }
}
