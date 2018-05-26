using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy.Qualificators
{
  public  class Quantyficator
    {
        private string _labelName;
        private IFunction _function;

        public IFunction Function
        {
            get { return _function; }
            set { _function = value; }
        }

        public string LablelName
        {
            get { return _labelName; }
            set { _labelName = value; }
        }

        public double count(double d)
        {
            return _function.count(d);
        }

        public double cardinalNumber()
        {
            return  _function.distance();
        }
    }
}
