using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    class Fuzzy1 : FuzzyLogic
    {
        double[] fuzzySet;
        private double[] membershipRatio;

        public Fuzzy1(IFunction function, double[] set) : base(function)
        {
            fuzzySet = set;
            membershipRatio= new double[set.Length];
            for (int i = 0; i < fuzzySet.Length; i++)
            {
                membershipRatio[i] = base.membership(fuzzySet[i]);
            }
        }

        public double[] getRatio()
        {
            return membershipRatio;
        }

    public override double cardinalNumber()
        {
            double cardinal = 0;
            foreach (var variable in membershipRatio)
            {
                cardinal += base.func.count(variable);
            }
            return cardinal;
        }
    }
}
