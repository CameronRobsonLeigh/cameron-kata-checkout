﻿using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService
    {
        private List<Product> _basket = new List<Product>();
        public int Scan(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.UnitPrice < 0)
                throw new ArgumentException("Product price cannot be negative", nameof(product.UnitPrice));

            _basket.Add(product);

            return _basket.Count;
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;

            // Group products by SKU (to apply bulk discounts per product type)
            var groupedProducts = _basket.GroupBy(p => p.SKU);

            foreach (var group in groupedProducts)
            {
                // get first option in group so we can interact with the data (should be consistent across the SKU group)
                // retrieve highest discount price if they discount prices are different per group
                Product? product = group.OrderByDescending(p => p.DiscountUnitPrice).FirstOrDefault();

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

            return total;
        }
    }
}
