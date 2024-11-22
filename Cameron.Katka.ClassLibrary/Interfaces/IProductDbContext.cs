using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IProductDbContext
    {
        IQueryable<Product> ProductsQueryable { get; }

        List<Product> ProductList { get; }
    }
}
