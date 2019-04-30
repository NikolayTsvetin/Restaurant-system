using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Soup : Food
    {
        private const int ServingSize = 245;

        public Soup(string name, decimal price) : base(name, ServingSize, price)
        {
        }
    }
}
