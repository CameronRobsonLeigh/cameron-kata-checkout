using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CheckoutService
    {
        private List<Product> _basket = new List<Product>();
        public int Scan(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (product.UnitPrice < 0)
                throw new ArgumentException("Product price cannot be negative", nameof(product.UnitPrice));

            _basket.Add(product);

            return _basket.Count;
        }
    }
}
