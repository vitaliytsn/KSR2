using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    class Label
    {
        private string labelName;
        private Fuzzy1 fuzz;
        public Label(string label, IFunction func,double[] fuzzySet)
        {
            labelName = label;
            fuzz = new Fuzzy1(func, fuzzySet);
        }

        public double getRatio()
        {
            double ratio = 0;
            foreach (var VARIABLE in fuzz.getRatio())
            {
                ratio += VARIABLE;
            }

            return ratio;
        }
    }
}
