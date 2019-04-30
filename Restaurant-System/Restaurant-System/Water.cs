using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Water : Drink
    {
        private const decimal Price = 1.5M;

        public Water(string name, int servingSize, string brand) : base(name, servingSize, Price, brand)
        {
        }
    }
}
