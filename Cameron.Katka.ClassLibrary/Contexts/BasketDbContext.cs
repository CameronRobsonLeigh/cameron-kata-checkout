using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;


namespace Cameron.Katka.ClassLibrary.Contexts
{
    public class BasketDbContext : IBasketDbContext
    {
        private List<Product> _basket;

        public BasketDbContext()
        {
            _basket = new List<Product>();
        }

        public IQueryable<Product> BasketQueryable => _basket.AsQueryable();

        public List<Product> Basket => _basket;
    }
}
