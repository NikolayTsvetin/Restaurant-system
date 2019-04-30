using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Juice : Drink
    {
        private const decimal Price = 1.8M;

        public Juice(string name, int servingSize, string brand) : base(name, servingSize, Price, brand)
        {
        }
    }
}
