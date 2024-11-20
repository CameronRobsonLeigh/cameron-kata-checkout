﻿using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary
{
    public interface IApplicationDbContext
    {
        IQueryable<Product> ProductsQueryable { get; }

        List<Product> ProductList { get; }
    }
}
