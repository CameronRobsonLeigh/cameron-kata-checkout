
namespace Cameron.Katka.ClassLibrary.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public int? DiscountUnits { get; set; }
        public decimal? DiscountUnitPrice { get; set; }

        public Product(string sku, decimal unitPrice, int? discountUnits = null, decimal? discountUnitPrice = null)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            DiscountUnits = discountUnits;
            DiscountUnitPrice = discountUnitPrice;
        }
    }
}
