using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductService
    {
        void UpdatePricingRules(List<PricingRule> pricingRules);
    }
}
