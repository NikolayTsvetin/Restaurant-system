﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_System
{
    public interface IFood
    {
        string GetName();
        decimal GetPrice();
        string ToString();
    }
}
