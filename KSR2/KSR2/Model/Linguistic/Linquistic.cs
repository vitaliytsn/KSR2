using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Fuzzy;

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
            using (StreamWriter writetext = new StreamWriter(@"output.txt"))
            {
                foreach (var lab in label)
                {
                    double d = 0;
                    foreach (var VARIABLE in lab.MembershipRatio)
                    {
                        if (VARIABLE > 0)
                            d += 1;
                    }

                    d = d / lab.MembershipRatio.Length;
                    Random rand = new Random();
                    int r = rand.Next(2);
                    string output = "";
            
                    if (r == 0)
                    {
                        d = Math.Round(d, 2);
                        output = "Around " + Convert.ToString(d) + " people are " + lab.LabelName;
                    }

                    if (r == 1)
                    {
                        if (d >= 0.4) output = "majority of people " + " are " + lab.LabelName;
                        if (d > 0.5 && d < 0.6) output = "more than half people " + " are " + lab.LabelName;
                        if (d < 0.5 && d > 0.4) output = "around the half people" + " are " + lab.LabelName;
                        if (d <= 0.4) output = "minority of people " + " are " + lab.LabelName;
                    }
                    writetext.WriteLine(output);
                }
            }
        }
    }
}
