﻿
namespace Cameron.Katka.ClassLibrary.Models
{
    public class Product
    {
        public string SKU { get; }
        public int UnitPrice { get; set; }

        public Product(string sku, int unitPrice)
        {
            SKU = sku;
            UnitPrice = unitPrice;
        }
    }
}
