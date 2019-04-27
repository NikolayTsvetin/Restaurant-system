using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class MainCourse : Food
    {
        public MainCourse(string name, decimal price) : base(name, 500, price)
        {
        }
    }
}
