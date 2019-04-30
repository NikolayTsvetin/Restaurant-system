using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class FuzzyDrink : Drink
    {
        private const decimal Price = 2.5M;

        public FuzzyDrink(string name, int servingSize, string brand) : base(name, servingSize, Price, brand)
        {
        }
    }
}
