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
            using (StreamWriter writetext = new StreamWriter(@"output_text.txt"))
            {
                using (StreamWriter writenumbers = new StreamWriter(@"output_numbers.txt"))
                {
                    if (qualificators == null)
                        writetext.Write(output1Form());
                }
            }
        }

        public string output1Form()// czyli bez kwalifikatora
        {
            string output = "";
            foreach (var lab in label)
                {
                    #region Kwantyfikator
                    //nasz kwantyfikator- bezwzględny
                    /*Q(a) = (0, a = 0,
                              1, a ∈ (0, 1].*/
                    #endregion
                    double max = -0.01;
                    Quantyficator selected = new Quantyficator();
                    string coverage = "";
                    double number = 0;
                    foreach (var quantyficator in quantyficators)
                    {
                        coverage += " " + Convert.ToString(Coefficients.degreeOfTruthfulness(quantyficator,lab));
                        number =
                            Coefficients.degreeOfTruthfulness(quantyficator,lab) + Coefficients.degreeOfImprecisionQuantyficator(
                                                                        quantyficator,lab)+Coefficients.degreesOfcardinalityQuantifier(quantyficator,lab)
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
                    output += selected.LablelName + " of people are " + lab.LabelName +
                             "    " + Convert.ToString(max)+" /r/n";
                    
                }
            return output;
        }
        public string output2Form()// czyli bez kwalifikatora
        {
            string output = "";
            foreach (var qua in qualificators)
            {
                #region Kwantyfikator
                //nasz kwantyfikator- bezwzględny
                /*Q(a) = (0, a = 0,
                          1, a ∈ (0, 1].*/
                #endregion
                double max = -0.01;
                Quantyficator selected = new Quantyficator();
                string coverage = "";
                double number = 0;
              /*  foreach (var quantyficator in quantyficators)
                {
                    coverage += " " + Convert.ToString(lab.degreeOfTruthfulness(quantyficator));
                    number =
                        lab.degreeOfTruthfulness(quantyficator) + lab.degreeOfImprecisionQuantyficator(
                                                                    quantyficator)
                                                                + lab.SumaryzatorLenght() +
                                                                lab.degreeOfCoverageSumaryzator() +
                                                                +lab.degreeOfCardinalitySumaryzator() +
                                                                lab.degreeOfImprecisionSumaryzator() +
                                                                lab.measureOfAccuracySumaryzator()
                        ;
                    number = number / 7;
                    if (number > max)
                    {
                        max = number;
                        selected = quantyficator;
                    }
                }
                output += selected.LablelName + " of people are " + lab.LabelName +
                         "    " + Convert.ToString(max) + " /r/n";*/

            }
            return output;
        }
    }
}
