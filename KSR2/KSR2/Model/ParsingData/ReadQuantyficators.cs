using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.ParsingData
{
    class ReadQuantyficators
    {
        public List<Quantyficator> read()
        {
            List<Quantyficator> quantyficators = new List<Quantyficator>();
            string[] lines = System.IO.File.ReadAllLines(@"input_Qualificators.txt");
            foreach (var line in lines)
            {
                Quantyficator q = new Quantyficator();
                int i = 0;
                string function = "";
                string coefitients = "";
                while (line[i] == ' ') i++;
                string s = "";
                while(line[i]!=' ') { s+=line[i];i++; }
                q.LablelName = s;
                s = "";
                while (line[i] == ' ') i++;
                while (line[i] != ' ') { s += line[i]; i++; }
                function = s;
                s = "";
                while (line[i] == ' ') i++;
                while (i<line.Length && line[i] != ' ') { s += line[i]; i++; }

                coefitients = s;
                if (function == "TriangleFunction")
                {
                    double a, b;
                    string number = "";
                    int j = 1;
                    while (coefitients[j] != ',')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    j++;
                    
                    a = Convert.ToDouble(number);
                    number = "";
                    while (coefitients[j] != ')')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    b = Convert.ToDouble(number);
                    q.Function= new TriangleFunc(a,b);
                }
                if (function == "TrapezoidFunction")
                {
                    double a, b,c,d;
                    string number = "";
                    int j = 1;
                    while (coefitients[j] != ',')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    j++;
                    a = Convert.ToDouble(number);
                    number = "";
                    while (coefitients[j] != ',')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    j++;
                    b = Convert.ToDouble(number);
                    number = "";
                    while (coefitients[j] != ',')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    j++;
                    c = Convert.ToDouble(number);
                    number = "";
                    while (coefitients[j] != ')')
                    {
                        number += coefitients[j];
                        j++;
                    }

                    d = Convert.ToDouble(number);
                    q.Function= new TrapezoidFunc(a,b,c,d);
                }
                quantyficators.Add(q);
            }

            return quantyficators;
        }
    }
}
