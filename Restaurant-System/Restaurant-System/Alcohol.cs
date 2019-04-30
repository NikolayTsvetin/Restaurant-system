using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Alcohol : Drink
    {
        private const decimal Price = 3.5M;

        public Alcohol(string name, int servingSize, string brand) : base(name, servingSize, Price, brand)
        {
        }
    }
}
