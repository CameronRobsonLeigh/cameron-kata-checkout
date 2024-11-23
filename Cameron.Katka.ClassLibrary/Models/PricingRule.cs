﻿
namespace Cameron.Katka.ClassLibrary.Models
{
    public class PricingRule
    {
        public string Sku { get; set; }

        public int UnitPrice { get; set; }

        public int? DiscountUnits { get; set; }

        public int? DiscountRate { get; set; }

        public PricingRule(string sku, int unitPrice, int? discountUnits, int? discountRate)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            DiscountUnits = discountUnits;
            DiscountRate = discountRate;
        }

        // overloaded constructor for no discount in rule
        public PricingRule(string sku, int unitPrice)
            : this(sku, unitPrice, null, null)
        {
        }
    }
}
