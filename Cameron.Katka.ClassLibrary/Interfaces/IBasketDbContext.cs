using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IBasketDbContext
    {
        IQueryable<Product> BasketQueryable { get; }

        List<Product> Basket { get; }
    }
}
