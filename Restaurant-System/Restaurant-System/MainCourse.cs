﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public class MainCourse : Food
    {
        private const int ServingSize = 500;
        public MainCourse(string name, decimal price) : base(name, ServingSize, price)
        {
        }
    }
}
