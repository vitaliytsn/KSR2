using System;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.Fuzzy
{
    internal static class Coefficients
    {
        public static double DegreeOfTruthfulness(Quantyficator q, Label label) //T1 Stopien prawdziwosci kwantyfikatora
        {
            return q.Count(label.CardinalNumber() * label.Fuzzy.FuzzySet.Length);
        }

        public static double DegreeOfImprecisionSumaryzator(Label lab) //T2  Stopien nieprecyzyjnosci Sumaryzatora
        {
            var t = lab.CardinalNumber();
            foreach (var label in lab.InsideLabels) t *= label.CardinalNumber();
            t = Math.Pow(t, (double) 1 / (lab.InsideLabels.Count + 1));
            return t;
        }

        public static double DegreeOfCoverageSumaryzator(Label lab) //T3  Stopien pokrycia Sumaryzatora
        {
            double h = 0;
            double t = 0;
            //D-cała baza
            //count(min(S and D))/Count(D)
            for (var i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
            {
                double k = 0;
                if (lab.Fuzzy.FuzzySet[i] < lab.MembershipRatio[i]) k = lab.Fuzzy.FuzzySet[i];
                if (lab.Fuzzy.FuzzySet[i] >= lab.MembershipRatio[i]) k = lab.MembershipRatio[i];
                if (k > 0) t++;
            }

            for (var i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
                if (lab.Fuzzy.FuzzySet[i] > 0)
                    h++;
            return t / h;
        }

        public static double MeasureOfAccuracySumaryzator(Label lab) //T4 Miara trafnosci Sumaryzatora
        {
            var t4 = lab.CardinalNumber();
            foreach (var label in lab.InsideLabels)
                if (label.CardinalNumber() > 0)
                    t4 *= label.CardinalNumber();
            return Math.Abs(t4 - DegreeOfCoverageSumaryzator(lab));
        }

        public static double SumaryzatorLenght(Label lab) //T5 Dlugosc podsumowania
        {
            return 2 * Math.Pow(0.5, lab.InsideLabels.Count + 1);
        }

        public static double[] Fillarr(Label lab) //czesc wspolna dla T6 i T7
        {
            var arr = new double[lab.Fuzzy.FuzzySet.Length];
            for (var i = 0; i < lab.Fuzzy.FuzzySet.Length; i++) arr[i] = i;
            return arr;
        }

        public static double DegreeOfCardinalitySumaryzator(Label lab) //T8  Stopien kardynalnosci Sumaryzatora
        {
            var summ = lab.CardinalNumber();
            foreach (var label in lab.InsideLabels) summ *= label.CardinalNumber();
            return 1 - Math.Pow(summ, (double) 1 / lab.MembershipRatio.Length);
        }

        public static double DegreesOfcardinalityQuantifier(Quantyficator q, Label lab) //T7
        {
            return 1 - q.CardinalNumber() / lab.MembershipRatio.Length;
        }

        public static double
            DegreeOfImprecisionQuantyficator(Quantyficator q, Label lab) //T6 Stopien nieprecyzyjnosci Kwantyfikatora
        {
            var arr = Fillarr(lab);
            for (var i = 0; i < lab.Fuzzy.FuzzySet.Length; i++) arr[i] = q.Count(arr[i]);

            double d = 0;

            foreach (var element in arr)
                if (element > 0)
                    d++;

            return d / lab.Fuzzy.FuzzySet.Length;
        }

        public static double
            DegreeOfImprecisionKwalifikator(Qualificator qua) //T9  Stopien nieprecyzyjnosci Kwalifiktora
        {
            var t = qua.CardinalNumber();
            foreach (var label in qua.InsideQualificators) t *= label.CardinalNumber();
            t = Math.Pow(t, (double) 1 / (qua.InsideQualificators.Count + 1));
            return 1 - t;
        }

        public static double DegreeOfCardinalityKwalifikator(Qualificator qua) //T10  Stopien kardynalnosci Sumaryzatora
        {
            return qua.CardinalNumber();
        }

        public static double KwalifikatorLenght(Qualificator qua) //T11 Dlugosc kwalifikatora
        {
            return 2 * Math.Pow(0.5, qua.InsideQualificators.Count + 1);
        }
    }
}