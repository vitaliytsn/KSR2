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

        public string LabelName
        {
            get { return labelName; }
        }
        public Fuzzy1 Fuzzy
        {
            get
            {
                return fuzz; 

            }
        }
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

        public void FuzzySumm(Label summ)//czyli and S norma
        {
            this.labelName = this.labelName +" and "+ summ.labelName;
            for (int i=0;i<fuzz.MembershipRatio.Length;i++)
            {
                if(summ.fuzz.MembershipRatio[i]< fuzz.MembershipRatio[i])
                fuzz.MembershipRatio[i] = summ.fuzz.MembershipRatio[i];
            }
        }

        public void FuzzySubraction(Label summ)//czyli or - T norma
        {
            this.labelName = this.labelName + " or " + summ.labelName;
            for (int i = 0; i < fuzz.MembershipRatio.Length; i++)
            {
                if (summ.fuzz.MembershipRatio[i] > fuzz.MembershipRatio[i])
                    fuzz.MembershipRatio[i] = summ.fuzz.MembershipRatio[i];
            }
        }
    }
}
