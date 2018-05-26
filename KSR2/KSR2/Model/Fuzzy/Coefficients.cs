using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.Fuzzy
{
   static class Coefficients
    {

        public static double degreeOfTruthfulness(Quantyficator q,Label label)//T1 Stopien prawdziwosci kwantyfikatora
        {
            return q.count(label.cardinalNumber() * label.Fuzzy.FuzzySet.Length);
        }

        public static double degreeOfImprecisionSumaryzator(Label lab)//T2  Stopien nieprecyzyjnosci Sumaryzatora
        {
            double t = lab.cardinalNumber();
            foreach (var label in lab.InsideLabels)
            {
                t *= label.cardinalNumber();
            }
            t = Math.Pow(t, (double)1 / (lab.InsideLabels.Count + 1));
            return t;
        }

        public static double degreeOfCoverageSumaryzator(Label lab)//T3  Stopien pokrycia Sumaryzatora
        {
            double h = 0;
            double t = 0;
            //D-cała baza
            //count(min(S and D))/Count(D)
            for (int i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
            {
                double k = 0;
                if (lab.Fuzzy.FuzzySet[i] < lab.MembershipRatio[i]) k = lab.Fuzzy.FuzzySet[i];
                if (lab.Fuzzy.FuzzySet[i] >= lab.MembershipRatio[i]) k = lab.MembershipRatio[i];
                if (k > 0) t++;
            }

            for (int i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
            {
                if (lab.Fuzzy.FuzzySet[i] > 0) h++;
            }
            return t / h;
        }

        public static double measureOfAccuracySumaryzator(Label lab)//T4 Miara trafnosci Sumaryzatora
        {
            double t4 = lab.cardinalNumber();
            foreach (var label in lab.InsideLabels)
            {
                if (label.cardinalNumber() > 0)
                    t4 *= label.cardinalNumber();
            }
            return Math.Abs(t4 - degreeOfCoverageSumaryzator(lab));
        }

        public static double SumaryzatorLenght(Label lab)//T5 Dlugosc podsumowania
        {

            return 2 * Math.Pow(0.5, lab.InsideLabels.Count + 1);
        }

        public static double[] fillarr(Label lab)//czesc wspolna dla T6 i T7
        {
            double[] arr = new double[lab.Fuzzy.FuzzySet.Length];
            for (int i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
            {
                arr[i] = i;
            }
            return arr;
        }

        public static double degreeOfCardinalitySumaryzator(Label lab)//T8  Stopien kardynalnosci Sumaryzatora
        {
            double summ = lab.cardinalNumber();
            foreach (var label in lab.InsideLabels)
            {
                summ *= label.cardinalNumber();
            }
            return 1 - Math.Pow(summ, (double)1 / lab.MembershipRatio.Length);
        }

        public static double degreesOfcardinalityQuantifier(Quantyficator q, Label lab)
        {
            return 0.5;
        }
        public static double degreeOfImprecisionQuantyficator(Quantyficator q,Label lab)//T6 Stopien nieprecyzyjnosci Kwantyfikatora
        {
            double[] arr = fillarr(lab);
            for (int i = 0; i < lab.Fuzzy.FuzzySet.Length; i++)
            {
                arr[i] = q.count(arr[i]);
            }

            double d = 0;

            foreach (var element in arr)
            {
                if (element > 0)
                    d++;
            }

            return 1 - d / lab.Fuzzy.FuzzySet.Length;
        }

        public static double degreeOfImprecisionKwalifikator(Qualificator qua)//T9  Stopien nieprecyzyjnosci Kwalifiktora
        {
            double t = qua.cardinalNumber();
            foreach (var label in qua.InsideQualificators)
            {
                t *= label.cardinalNumber();
            }
            t = Math.Pow(t, (double)1 / (qua.InsideQualificators.Count + 1));
            return t;
        }
        public static double degreeOfCardinalityKwalifikator(Qualificator qua)//T10  Stopien kardynalnosci Sumaryzatora
        {
            return  qua.cardinalNumber();
        }
        public static double KwalifikatorLenght(Qualificator qua)//T11 Dlugosc kwalifikatora
        {
            return 2 * Math.Pow(0.5, qua.InsideQualificators.Count + 1);
        }
    }
}
