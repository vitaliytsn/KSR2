using System.Collections.Generic;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    internal class Qualificator
    {
        private Fuzzy1 _fuzz;

        public Qualificator(string name, IFunction func, Label label, Fuzzy1 fuzz)
        {
            InsideQualificators = new List<Qualificator>();
            QualificatorName = name;
            Labell = label;
            Function = func;
            _fuzz = fuzz;
            MembershipRatio = new double[Labell.Fuzzy.FuzzySet.Length];
            for (var i = 0; i < Labell.Fuzzy.FuzzySet.Length; i++) MembershipRatio[i] = Membership(fuzz.FuzzySet[i]);

            for (var i = 0; i < MembershipRatio.Length; i++)
                if (MembershipRatio[i] > Labell.MembershipRatio[i])
                    MembershipRatio[i] = Labell.MembershipRatio[i];

            Labell.MembershipRatio = MembershipRatio;
        }


        public List<Qualificator> InsideQualificators { get; }


        public string QualificatorName { get; }

        public Label Labell { get; }

        public IFunction Function { get; set; }

        public double[] MembershipRatio { get; set; }

        public double Membership(double x)
        {
            return Function.Count(x);
        }

        public double CardinalNumber()
        {
            double cardinal = 0;
            foreach (var variable in MembershipRatio)
                if (variable > 0)
                    cardinal += 1;
            return cardinal / Labell.MembershipRatio.Length;
        }
    }
}