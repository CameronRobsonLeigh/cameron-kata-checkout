
namespace Cameron.Katka.ClassLibrary.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }

        public Product(string sku, decimal unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}
