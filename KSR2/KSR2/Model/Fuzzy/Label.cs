using System.Collections.Generic;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    internal class Label
    {
        //sumaryzator

        public Label(string label, IFunction func, Fuzzy1 fuzzy)
        {
            InsideLabels = new List<Label>();
            LabelName = label;
            Fuzzy = fuzzy;
            Function = func;
            MembershipRatio = new double[Fuzzy.FuzzySet.Length];
            for (var i = 0; i < Fuzzy.FuzzySet.Length; i++) MembershipRatio[i] = Membership(Fuzzy.FuzzySet[i]);
        }

        public Label(Label label)
        {
            InsideLabels = new List<Label>();
            foreach (var lab in label.InsideLabels) InsideLabels.Add(new Label(lab));
            LabelName = label.LabelName;
            Function = label.Function;
            Fuzzy = label.Fuzzy;
            MembershipRatio = new double[Fuzzy.FuzzySet.Length];
            for (var i = 0; i < label.MembershipRatio.Length; i++) MembershipRatio[i] = label.MembershipRatio[i];
        }

        public string LabelName { get; private set; }

        public Fuzzy1 Fuzzy { get; }

        public List<Label> InsideLabels { get; }

        public IFunction Function { get; set; }

        public double[] MembershipRatio { get; set; }

        public double Membership(double x)
        {
            return Function.Count(x);
        }

        public void FuzzySum(Label summ) //czyli or - S norma
        {
            InsideLabels.Add(summ);
            LabelName = LabelName + " or " + summ.LabelName;
            for (var i = 0; i < MembershipRatio.Length; i++)
                if (summ.MembershipRatio[i] > 0 || MembershipRatio[i] > 0
                ) // && !(summ._membershipRatio[i] > 0 && _membershipRatio[i] > 0))
                    MembershipRatio[i] = summ.MembershipRatio[i];
                else
                    MembershipRatio[i] = 0;
        }

        public void FuzzySubtraction(Label summ) //czyli and T norma
        {
            InsideLabels.Add(summ);
            LabelName = LabelName + " and " + summ.LabelName;
            for (var i = 0; i < MembershipRatio.Length; i++)
                if (summ.MembershipRatio[i] > 0 && MembershipRatio[i] > 0)
                    MembershipRatio[i] = summ.MembershipRatio[i];
                else
                    MembershipRatio[i] = 0;
        }


        public double CardinalNumber()
        {
            double cardinal = 0;
            foreach (var variable in MembershipRatio)
                if (variable > 0)
                    cardinal += 1;
            return cardinal / Fuzzy.FuzzySet.Length;
        }
    }
}