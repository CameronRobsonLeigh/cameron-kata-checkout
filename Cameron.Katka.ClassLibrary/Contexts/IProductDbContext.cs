using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Contexts
{
    public interface IProductDbContext
    {
        IQueryable<Product> ProductsQueryable { get; }

        List<Product> ProductList { get; }
    }
}
