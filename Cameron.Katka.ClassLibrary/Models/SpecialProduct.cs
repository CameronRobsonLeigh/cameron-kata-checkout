
namespace Cameron.Katka.ClassLibrary.Models
{
    public class SpecialProduct: Product
    {
        public int? DiscountUnits { get; set; }
        public int? DiscountUnitPrice { get; set; }

        public SpecialProduct(string sku, int unitPrice, int? discountUnits, int? discountPrice) : base(sku, unitPrice)
        {
            DiscountUnits = discountUnits;
            DiscountUnitPrice = discountPrice;
        }
    }
}
