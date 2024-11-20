using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cameron.Katka.ClassLibrary.Models
{
    public class SpecialProduct: Product
    {
        public int DiscountUnits { get; set; }
        public decimal DiscountUnitPrice { get; set; }

        public SpecialProduct(string sku, decimal unitPrice, int discountUnits, decimal discountPrice) : base(sku, unitPrice)
        {
            DiscountUnits = discountUnits;
            DiscountUnitPrice = discountPrice;
        }
    }
}
