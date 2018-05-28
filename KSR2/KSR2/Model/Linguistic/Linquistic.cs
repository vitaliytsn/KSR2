using System;
using System.Collections.Generic;
using System.IO;
using KSR2.Model.Fuzzy;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.LinguisticSum
{
    internal class Linquistic //clasa od Yagera
    {
        private readonly List<Label> _label;
        private readonly List<Qualificator> _qualificators;
        private readonly List<Quantyficator> _quantyficators;

        public Linquistic(List<Label> label, List<Quantyficator> quantyficators)
        {
            _quantyficators = quantyficators;
            _label = label;
            _qualificators = null;
        }

        public Linquistic(List<Qualificator> qualificators, List<Quantyficator> quantyficators)
        {
            _quantyficators = quantyficators;
            _qualificators = qualificators;
            _label = null;
        }

        public void GenerateOutput()
        {
            if (_qualificators == null)
                Output1Form();
            else
                Output2Form();
        }

        public void Output1Form() // czyli bez kwalifikatora
        {
            using (var writetext = new StreamWriter(@"output_1text.txt"))
            {
                foreach (var lab in _label)
                {
                    var output = "";
                    //T1-T5

                    #region Kwantyfikator

                    //nasz kwantyfikator- bezwzględny
                    /*Q(a) = (0, a = 0,
                              1, a ∈ (0, 1].*/

                    #endregion

                    var max = -0.01;
                    var selected = new Quantyficator();

                    double number = 0;
                    foreach (var quantyficator in _quantyficators)
                    {
                        number =
                            Coefficients.DegreeOfTruthfulness(quantyficator, lab) +
                            Coefficients.SumaryzatorLenght(lab) +
                            Coefficients.DegreeOfCoverageSumaryzator(lab) +
                            +
                                Coefficients.DegreeOfImprecisionSumaryzator(lab) +
                            Coefficients.MeasureOfAccuracySumaryzator(lab)
                            ;
                        number = number / 5;
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

        public void Output2Form() // czyli bez kwalifikatora
        {
            using (var writetext = new StreamWriter(@"output_2text.txt"))
            {
                foreach (var qua in _qualificators)
                {
                    var output = "";
                    //T1-T11
                    var max = -0.01;
                    var selected = new Quantyficator();
                    double number = 0;
                    foreach (var quantyficator in _quantyficators)
                    {
                        number =
                            Coefficients.DegreeOfTruthfulness(quantyficator, qua.Labell) +
                            Coefficients.DegreeOfImprecisionQuantyficator(
                                quantyficator, qua.Labell) +
                            Coefficients.DegreesOfcardinalityQuantifier(quantyficator, qua.Labell)
                            + Coefficients.SumaryzatorLenght(qua.Labell) +
                            Coefficients.DegreeOfCoverageSumaryzator(qua.Labell) +
                            +Coefficients.DegreeOfCardinalitySumaryzator(qua.Labell) +
                            Coefficients.DegreeOfImprecisionSumaryzator(qua.Labell) +
                            Coefficients.MeasureOfAccuracySumaryzator(qua.Labell) +
                            Coefficients.DegreeOfImprecisionKwalifikator(qua) +
                            Coefficients.DegreeOfCardinalityKwalifikator(qua) +
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