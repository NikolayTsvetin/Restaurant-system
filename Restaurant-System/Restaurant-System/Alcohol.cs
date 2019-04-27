using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class Alcohol : Drink
    {
        public Alcohol(string name, int servingSize, string brand) : base(name, servingSize, 3.5M, brand)
        {
        }
    }
}
