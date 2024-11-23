using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;


namespace Cameron.Katka.ClassLibrary.Contexts
{
    internal class BasketContext : IBasketDbContext
    {
        private List<Product> _basket;

        public BasketContext()
        {
            _basket = new List<Product>();
        }

        public IQueryable<Product> BasketQueryable => _basket.AsQueryable();

        public List<Product> Basket => _basket;
    }
}
