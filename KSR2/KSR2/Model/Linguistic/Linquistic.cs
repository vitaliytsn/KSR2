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
        public Linquistic(List<Label> label)
        {
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

                        d = d / lab.MembershipRatio.Length;

                        #endregion

                        #region Kwalifikator

                        Qualificator qualificator;

                        #endregion


                        Random rand = new Random();
                        rand.Next(984);
                        int r = rand.Next(2);
                        string output = "";
                        string outputNumbers = "";
                        r = 0;
                        if (r == 0)
                        {
                            qualificator = new NumberQualificator();
                            output = qualificator.qualify(d, lab.LabelName);
                        }

                        if (r == 1)
                        {
                            qualificator = new AbstractQualificator();
                            output = qualificator.qualify(d, lab.LabelName);
                        }
                        //Nieprecyzyjnosc Stopien Pokrycia MiaraTrafnosci
                        outputNumbers =Convert.ToString(lab.degreeOfImprecision1())
                                     + " " + Convert.ToString(lab.degreeOfCoverage()) +
                                     " " + Convert.ToString(lab.measureOfAccuracy());
                        writenumbers.WriteLine(outputNumbers);
                        writetext.WriteLine(output);
                    }
                }
            }
        }
    }
}
