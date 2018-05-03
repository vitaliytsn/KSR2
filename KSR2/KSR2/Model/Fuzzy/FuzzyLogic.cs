using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;
using Microsoft.SqlServer.Server;

namespace KSR2.Model.Fuzzy
{
   abstract class FuzzyLogic
    {
        protected IFunction func;

        public FuzzyLogic(IFunction function)
        {
            func = function;
        }
        public double membership(double x)
        {
            return func.count(x);
        }
        public abstract double cardinalNumber(double[] arr);
    }
}
