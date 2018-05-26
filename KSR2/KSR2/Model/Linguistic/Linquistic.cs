using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Fuzzy;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.LinguisticSum
{
    class Linquistic //clasa od Yagera
    {
        private List<Qualificator> qualificators;
        private List<Label> label;
        private List<Quantyficator> quantyficators;
        public Linquistic(List<Label> label, List<Quantyficator> quantyficators)
        {
            this.quantyficators = quantyficators;
            this.label = label;
            qualificators = null;
        }
        public Linquistic(List<Qualificator> qualificators, List<Quantyficator> quantyficators)
        {
            this.quantyficators = quantyficators;
            this.qualificators = qualificators;
            label = null;
        }

        public void generateOutput()
        {
            if (qualificators == null)
                output1Form();
            else
            {
                output2Form();
            }
        }

        public void output1Form()// czyli bez kwalifikatora
        {
            using (StreamWriter writetext = new StreamWriter(@"output_1text.txt"))
            {

                foreach (var lab in label)
                {
                    string output = "";
                    //T1-T8

                    #region Kwantyfikator

                    //nasz kwantyfikator- bezwzględny
                    /*Q(a) = (0, a = 0,
                              1, a ∈ (0, 1].*/

                    #endregion

                    double max = -0.01;
                    Quantyficator selected = new Quantyficator();

                    double number = 0;
                    foreach (var quantyficator in quantyficators)
                    {
                        number =
                            Coefficients.degreeOfTruthfulness(quantyficator, lab) +
                            Coefficients.degreeOfImprecisionQuantyficator(
                                quantyficator, lab) + Coefficients.degreesOfcardinalityQuantifier(quantyficator, lab)
                            + Coefficients.SumaryzatorLenght(lab) +
                            Coefficients.degreeOfCoverageSumaryzator(lab) +
                            +Coefficients.degreeOfCardinalitySumaryzator(lab) +
                            Coefficients.degreeOfImprecisionSumaryzator(lab) +
                            Coefficients.measureOfAccuracySumaryzator(lab)
                            ;
                        number = number / 8;
                        if (number > max)
                        {
                            max = number;
                            selected = quantyficator;
                        }
                    }

                    output = selected.LablelName + " of people are " + lab.LabelName +
                              "    " + Convert.ToString(max);
                    writetext.WriteLine(output);

                }
            }
        }
        public void output2Form()// czyli bez kwalifikatora
        {
            using (StreamWriter writetext = new StreamWriter(@"output_2text.txt"))
            {

                foreach (var qua in qualificators)
                {
                    string output = "";
                    //T1-T11
                    double max = -0.01;
                    Quantyficator selected = new Quantyficator();
                    double number = 0;
                    foreach (var quantyficator in quantyficators)
                    {
                        number =
                            Coefficients.degreeOfTruthfulness(quantyficator, qua.Labell) +
                            Coefficients.degreeOfImprecisionQuantyficator(
                                quantyficator, qua.Labell) +
                            Coefficients.degreesOfcardinalityQuantifier(quantyficator, qua.Labell)
                            + Coefficients.SumaryzatorLenght(qua.Labell) +
                            Coefficients.degreeOfCoverageSumaryzator(qua.Labell) +
                            +Coefficients.degreeOfCardinalitySumaryzator(qua.Labell) +
                            Coefficients.degreeOfImprecisionSumaryzator(qua.Labell) +
                            Coefficients.measureOfAccuracySumaryzator(qua.Labell) +
                            Coefficients.degreeOfImprecisionKwalifikator(qua) +
                            Coefficients.degreeOfCardinalityKwalifikator(qua) +
                            Coefficients.KwalifikatorLenght(qua)
                            ;
                        number = number / 11;
                        if (number > max)
                        {
                            max = number;
                            selected = quantyficator;
                        }
                    }

                    output = selected.LablelName + " of people " + qua.QualificatorName + " are " +
                              qua.Labell.LabelName +
                              "    " + Convert.ToString(max);
                    writetext.WriteLine(output);
                }
            }


        }
    }
}
