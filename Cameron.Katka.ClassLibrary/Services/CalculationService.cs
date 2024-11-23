using Cameron.Katka.ClassLibrary.Interfaces;
using Cameron.Katka.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cameron.Katka.ClassLibrary.Services
{
    public class CalculationService : ICalculationService
    {
        public int CalculateStandardProducts(List<Product> products)
        {
            int calculatePriceOfFilteredProducts = (int)products.Sum(p => p.UnitPrice);

            return calculatePriceOfFilteredProducts;
        }
    }
}
