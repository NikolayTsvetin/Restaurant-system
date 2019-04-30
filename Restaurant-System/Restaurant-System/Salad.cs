using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Salad : Food
    {
        private const int ServingSize = 300;

        public Salad(string name, decimal price) : base(name, ServingSize, price)
        {
        }
    }
}
