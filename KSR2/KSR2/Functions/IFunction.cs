﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Functions
{
  public  interface IFunction
    {
        double count(double x);
        double distance();
        double square();
    }
}
