namespace Cameron.Katka.ClassLibrary.Dto
{
    public class PricingRule
    {
        public string Sku { get; }

        public int UnitPrice { get; }

        public int? DiscountUnits { get; }

        public int? DiscountRate { get; }

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
