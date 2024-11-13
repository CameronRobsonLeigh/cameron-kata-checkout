﻿using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService
    {
        private List<Product> _basket = new List<Product>();
        public int Scan(Product product)
        {
            _basket.Add(product);

            return _basket.Count;
        }
    }
}
