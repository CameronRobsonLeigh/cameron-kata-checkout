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
            decimal total = 0;

            // Group products by SKU (to apply bulk discounts per product type)
            var groupedProducts = products.GroupBy(p => p.SKU);

            foreach (var group in groupedProducts)
            {
                // get first option in group so we can interact with the data (should be consistent across the SKU group)
                // retrieve highest discount price if they discount prices are different per group
                SpecialProduct? product = group.OrderByDescending(p => p.SKU).FirstOrDefault();

                // don't think this is needed as we check for null in the scan phase but keeps warnings happy
                if (product == null)
                    continue;

                int discountBundles = group.Count() / product.DiscountUnits.GetValueOrDefault(1);
                // calculate what is left, e.g. if there is 4 A products, then we discount the 3 but leave the remaining 1 at full price
                int remainingUnits = group.Count() % product.DiscountUnits.GetValueOrDefault(1);

                // add to the total the discounted bundle price, e.g. 3 A products = 130
                total += discountBundles * product.DiscountUnitPrice.GetValueOrDefault(product.UnitPrice);

                // any remaining units that don't have a discount bundle 
                total += remainingUnits * product.UnitPrice;

            }

            return (int)total;
        }
    }
}
