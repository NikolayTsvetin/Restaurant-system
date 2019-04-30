using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Dessert : Food
    {
        private const int ServingSize = 200;

        public Dessert(string name, decimal price) : base(name, ServingSize, price)
        {
        }
    }
}
