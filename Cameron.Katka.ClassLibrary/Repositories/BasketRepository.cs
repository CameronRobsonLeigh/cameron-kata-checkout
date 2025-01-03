﻿using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Repositories
{
    internal class BasketRepository : IBasketRepository
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

        public List<Product> GetAllStandardProductsScanned()
        {
            List<Product> getProductsInbasket = _context.BasketQueryable.Where(p => !(p is SpecialProduct)).ToList();

            return getProductsInbasket;
        }

        public List<SpecialProduct> GetAllDiscountedProductsScanned()
        {
            List<SpecialProduct> getProductsInbasket = _context.BasketQueryable.OfType<SpecialProduct>().ToList();

            return getProductsInbasket;
        }
    }
}
