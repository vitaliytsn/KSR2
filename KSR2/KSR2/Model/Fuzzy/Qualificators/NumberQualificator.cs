using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Fuzzy.Qualificators
{
    class NumberQualificator
    {
        public  string qualify(double cardinalNumber,string labelName)
        {
            if(cardinalNumber-0.01 == Math.Round(cardinalNumber, 3))
            return "Around " + Convert.ToString(Math.Round(cardinalNumber, 2)) + " people are " + labelName;

            if (cardinalNumber  == Math.Round(cardinalNumber, 3) + 0.01)
                return "Around " + Convert.ToString(Math.Round(cardinalNumber, 2)) + " people are " + labelName;

            if (Math.Round(cardinalNumber, 3) > cardinalNumber)
                return "Little less then " + Convert.ToString(Math.Round(cardinalNumber, 2)) + " people are " + labelName;

            if (Math.Round(cardinalNumber, 3)< cardinalNumber)
                return "Almost "+Convert.ToString(Math.Round(cardinalNumber, 2)) + " people are " + labelName;

            return "Around " + Convert.ToString(Math.Round(cardinalNumber, 2)) + " people are " + labelName;
        }
    }
}
