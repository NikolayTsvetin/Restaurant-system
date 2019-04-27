using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Salad : Food
    {
        public Salad(string name, decimal price) : base(name, 300, price)
        {
        }
    }
}
