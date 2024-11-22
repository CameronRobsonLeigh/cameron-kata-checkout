using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketDbContext _context;

        public BasketRepository(IBasketDbContext context)
        {
            _context = context;   
        }

        public List<Product> GetAllProductsFromBasket()
        {
            List<Product> getProductsInbasket = _context.BasketQueryable.ToList();

            return getProductsInbasket;
        }

    }
}
