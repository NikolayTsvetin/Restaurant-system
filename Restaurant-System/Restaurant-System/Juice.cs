using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Juice : Drink
    {
        public Juice(string name, int servingSize, string brand) : base(name, servingSize, 1.8M, brand)
        {
        }
    }
}
