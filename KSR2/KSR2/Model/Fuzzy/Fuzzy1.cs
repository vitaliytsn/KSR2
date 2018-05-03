using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    class Fuzzy1:FuzzyLogic
    {
        public Fuzzy1(IFunction function) : base(function)
        {
        }

        public override double cardinalNumber(double[] arr)
        {
            double cardinal = 0;
            foreach (var variable in arr)
            {
                cardinal += base.func.count(variable);
            }
            return cardinal;
        }
    }
}
