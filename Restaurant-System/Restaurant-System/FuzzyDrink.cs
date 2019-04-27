using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class FuzzyDrink : Drink
    {
        public FuzzyDrink(string name, int servingSize, string brand) : base(name, servingSize, 2.5M, brand)
        {
        }
    }
}
