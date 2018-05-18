using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Fuzzy.Qualificators
{
    class NumberQualificator:Qualificator
    {
        public  string qualify(double cardinalNumber,string labelName)
        {
            cardinalNumber = Math.Round(cardinalNumber, 2);
           return "Around " + Convert.ToString(cardinalNumber) + " people are " + labelName;
        }
    }
}
