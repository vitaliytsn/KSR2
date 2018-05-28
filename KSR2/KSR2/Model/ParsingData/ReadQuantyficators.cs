using System;
using System.Collections.Generic;
using System.IO;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy.Qualificators;

namespace KSR2.Model.ParsingData
{
    internal class ReadQuantyficators
    {
        public List<Quantyficator> Read()
        {
            var quantyficators = new List<Quantyficator>();
            var lines = File.ReadAllLines(@"input_Quantyficators.txt");
            foreach (var line in lines)
            {
                var q = new Quantyficator();
                var i = 0;
                var function = "";
                var coefitients = "";
                while (line[i] == ' ') i++;
                var s = "";
                while (line[i] != ' ')
                {
                    s += line[i];
                    i++;
                }

                q.LablelName = s;
                s = "";
                while (line[i] == ' ') i++;
                while (line[i] != ' ')
                {
                    s += line[i];
                    i++;
                }

                function = s;
                s = "";
                while (line[i] == ' ') i++;
                while (i < line.Length && line[i] != ' ')
                {
                    s += line[i];
                    i++;
                }

                coefitients = s;
                if (function == "TriangleFunction")
                {
                    double a, b;
                    var number = "";
                    var j = 1;
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
                    q.Function = new TriangleFunc(a, b);
                }

                if (function == "TrapezoidFunction")
                {
                    double a, b, c, d;
                    var number = "";
                    var j = 1;
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
                    q.Function = new TrapezoidFunc(a, b, c, d);
                }

                quantyficators.Add(q);
            }

            return quantyficators;
        }
    }
}