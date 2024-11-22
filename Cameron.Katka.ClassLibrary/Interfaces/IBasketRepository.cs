﻿
using Cameron.Katka.ClassLibrary.Models;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface IBasketRepository
    {
        List<Product> GetAllProductsFromBasket();
    }
}
