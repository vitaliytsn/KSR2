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
    class Linquistic
    {

        private List<Label> label;
        private List<Quantyficator> quantyficators;
        public Linquistic(List<Label> label, List<Quantyficator> quantyficators)
        {
            this.quantyficators = quantyficators;
            this.label = label;
        }

        public void generateOutput()
        {
            using (StreamWriter writetext = new StreamWriter(@"output_text.txt"))
            {
                using (StreamWriter writenumbers = new StreamWriter(@"output_numbers.txt"))
                {
                    foreach (var lab in label)
                    {
                        #region Kwantyfikator

                        //nasz kwantyfikator- bezwzględny
                        /*Q(a) = (0, a = 0,
                                  1, a ∈ (0, 1].*/
                        double d = 0;
                        foreach (var VARIABLE in lab.MembershipRatio)
                        {
                            if (VARIABLE > 0)
                                d += 1;
                        }

                       

                        #endregion

                        #region Kwalifikator

                        //Qualificator qualificator;

                        #endregion


                        Random rand = new Random();
                        rand.Next(984);
                        int r = rand.Next(2);
                        string output = "";
                        string outputNumbers = "";
                        r = 1;
                        double max = -0.01;
                        Quantyficator selected= new Quantyficator();

                        string coverage = "";
                        double number = 0;
                        foreach (var quantyficator in quantyficators)
                        {
                            coverage+=" "+ Convert.ToString(lab.degreeOfTruthfulness(quantyficator));
                            number = lab.degreeOfTruthfulness(quantyficator) + lab.degreeOfCoverage() +
                                     lab.degreeOfImprecision1() + lab.measureOfAccuracy();
                            number = number / 4;
                            if (number > max)
                            {
                                max = number;
                                selected = quantyficator;
                            }
                        }

                        output = selected.LablelName + " of people are " + lab.LabelName+
                                     "    " + Convert.ToString(max);
                        writenumbers.WriteLine(outputNumbers);
                        writetext.WriteLine(output);
                    }
                }
            }
        }
    }
}
