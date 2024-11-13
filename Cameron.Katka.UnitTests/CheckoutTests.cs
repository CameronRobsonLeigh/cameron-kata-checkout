﻿using Cameron.Katka.ClassLibrary.Models;
using Cameron.Katka.ClassLibrary.Services;

namespace Cameron.Katka.UnitTests
{
    internal class CheckoutTests
    {
        private CheckoutService _checkoutService;

        [SetUp]
        public void Setup()
        {
            _checkoutService = new CheckoutService();
        }

        [Test]
        public void Product_Should_Scan()
        {
            Product product = new Product("A", 50.00m, 3, 130.00m);
            int productCount = _checkoutService.Scan(product);
            Assert.AreEqual(1, productCount);
        }

        [Test]
        public void Scan_Product_Should_ThrowException_When_ProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _checkoutService.Scan(null));
        }

        [Test]
        public void Scan_Product_Should_Have_NegativePrice()
        {
            Product productWithNegativePrice = new Product("A", -50.00m, 3, 130.00m);
            Assert.Throws<ArgumentException>(() => _checkoutService.Scan(productWithNegativePrice), "Product price cannot be negative");
        }

        [Test]
        public void ScanMultipleProducts_Should_Increase_Basket_Count()
        {
            var product1 = new Product("A", 50.00m, 1, 40.00m);
            var product2 = new Product("B", 30.00m, 2, 25.00m);

            _checkoutService.Scan(product1); 
            int countAfterFirstScan = _checkoutService.Scan(product2); 

            Assert.AreEqual(2, countAfterFirstScan);  
        }

    }
}
