using Cameron.Katka.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cameron.Katka.ClassLibrary.Interfaces
{
    public interface ICalculationService
    {
        int CalculateStandardProducts(List<Product> products);

        int CalculateDiscountedProducts(List<SpecialProduct> products);
    }
}
