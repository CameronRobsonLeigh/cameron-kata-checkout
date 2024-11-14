using Cameron.Katka.ClassLibrary.Models;
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
            Assert.That(productCount, Is.EqualTo(1));
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
        public void Scan_Multiple_Products_Should_Increase_Basket_Count()
        {
            Product product1 = new Product("A", 50.00m, 1, 40.00m);
            Product product2 = new Product("B", 30.00m, 2, 25.00m);

            _checkoutService.Scan(product1); 
            int countAfterFirstScan = _checkoutService.Scan(product2);

            Assert.That(countAfterFirstScan, Is.EqualTo(2));
        }

        [Test]
        public void Calculate_Basic_Total_No_Discount()
        {
            Product prod = new Product("A", 50.00m, 1, 40.00m);

            int scanProd = _checkoutService.Scan(prod);
            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(50.00m));
        }

        [Test]
        public void Calculate_Total_With_Discounts()
        {
            Product prod = new Product("A", 50.00m, 3, 130.00m);
            Product prod2 = new Product("A", 50.00m, 3, 130.00m);
            Product prod3 = new Product("A", 50.00m, 3, 130.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(130.00m));

        }

        [Test]
        public void Calculate_Total_With_Different_Discount_Prices_Same_SKU()
        {
            Product prod = new Product("A", 50.00m, 3, 90.00m);
            Product prod2 = new Product("A", 50.00m, 3, 110.00m);
            Product prod3 = new Product("A", 50.00m, 3, 6.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(110.00m));
        }

        [Test]
        public void Check_Total_Should_Be_0_When_Empty_Basket()
        {
            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(0));
        }


        [Test]
        public void Calculate_Total_With_Different_Products()
        {
            Product prod = new Product("B", 30.00m, 2, 45.00m);
            Product prod2 = new Product("A", 50.00m, 3, 130.00m);
            Product prod3 = new Product("B", 30.00m, 2, 45.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(95.00m));
        }

        [Test]
        public void Calculate_Total_With_Different_Products_No_Discounts_Added()
        {
            Product prod = new Product("B", 30.00m, 2, 45.00m);
            Product prod2 = new Product("A", 50.00m, 3, 130.00m);
            Product prod3 = new Product("B", 30.00m, 2, 45.00m);
            Product prod4 = new Product("C", 20.00m);
            Product prod5 = new Product("C", 20.00m);
            Product prod6 = new Product("D", 15.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);
            int scanProd4 = _checkoutService.Scan(prod4);
            int scanProd5 = _checkoutService.Scan(prod5);
            int scanProd6 = _checkoutService.Scan(prod6);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(150.00m));
        }


        [Test]
        public void Calculate_Total_Price_Just_No_Discounts()
        {
            Product prod = new Product("C", 20.00m);
            Product prod2 = new Product("C", 20.00m);
            Product prod3 = new Product("D", 15.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(55.00m));
        }

        [Test]
        public void Calculate_Total_Price_No_Discount_A_SKU()
        {
            Product prod = new Product("A", 50.00m);
            Product prod2 = new Product("A", 50.00m);
            Product prod3 = new Product("A", 50.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(130.00m));
        }

        [Test]
        public void Scan_New_Products()
        {
            Product prod = new Product("E", 800.00m);
            Product prod2 = new Product("F", 30.00m, 2, 65.00m);
            Product prod3 = new Product("F", 30.00m, 2, 65.00m);

            int scanProd = _checkoutService.Scan(prod);
            int scanProd2 = _checkoutService.Scan(prod2);
            int scanProd3 = _checkoutService.Scan(prod3);

            decimal retrieveTotal = _checkoutService.GetTotalPrice();

            Assert.That(retrieveTotal, Is.EqualTo(865.00m));
        }
    }
}
