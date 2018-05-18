using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Fuzzy.Qualificators
{
    public interface Qualificator
    {
         string qualify(double cardinalNumber,string labelName);
    }
}
