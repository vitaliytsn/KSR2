using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Fuzzy.Qualificators
{
    class AbstractQualificator
    {
        public  string qualify(double cardinalNumber,string labelName)
        {
            string output = "";
            if (cardinalNumber >= 0.4) output = "majority of people " + " are " + labelName;
            if (cardinalNumber > 0.5 && cardinalNumber < 0.6) output = "more than half people " + " are " + labelName;
            if (cardinalNumber < 0.5 && cardinalNumber > 0.4) output = "around the half people" + " are " + labelName;
            if (cardinalNumber <= 0.4) output = "minority of people " + " are " + labelName;
            return output;
        }
    }
}
