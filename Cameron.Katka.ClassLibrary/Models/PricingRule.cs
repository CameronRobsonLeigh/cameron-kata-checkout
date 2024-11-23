using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cameron.Katka.ClassLibrary.Models
{
    public class PricingRule
    {
        public string Sku { get; set; }

        public int UnitPrice { get; set; }

        public int? DiscountUnits { get; set; }

        public int? DiscountRate { get; set; }

        public PricingRule(string sku, int unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}
