
using Cameron.Katka.ClassLibrary.Dto;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductService
    {
        void UpdatePricingRules(List<PricingRule> pricingRules);
    }
}
