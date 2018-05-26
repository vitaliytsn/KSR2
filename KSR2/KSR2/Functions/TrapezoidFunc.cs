using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Functions
{
    public class TrapezoidFunc:IFunction
    {
        private double a;
        private double b;
        private double c;
        private double d;
        //      a       c

        //b                  d
        public TrapezoidFunc(double a,double b,double c,double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double square()
        {
            return (a - b) * (d - c);
        }
        public double distance()
        {
            return d-b;
        }
        public double count(double x)
        {
            if (x >= a && x <= c) return 1;
            if (x > b && x < a) return (x - b) / (a - b);
            if (x > c && x < d) return (d - x) / (d - c);
            return 0;
        }
    }
}
