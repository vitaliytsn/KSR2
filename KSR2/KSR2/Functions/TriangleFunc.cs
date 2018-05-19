using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR2.Model.Functions
{
    public class TriangleFunc : IFunction
    {
        private double _etykietNum;
        private double _etykietaDys;
        public TriangleFunc(double etykietaNum,double etykietaDys)
        {
            _etykietNum = etykietaNum;
            _etykietaDys = etykietaDys;
        }

        public TriangleFunc(TriangleFunc fun)
        {
            _etykietNum = fun._etykietNum;
            _etykietaDys = fun._etykietaDys;
        }
        public double count(double x)
        {
            if (x > _etykietNum-_etykietaDys && x < _etykietNum+_etykietaDys)
            {
                if(x<=_etykietNum)
                return Math.Abs(Math.Abs(_etykietNum)-_etykietaDys-Math.Abs(x))/_etykietaDys;
                else return Math.Abs(Math.Abs(_etykietNum) + _etykietaDys - Math.Abs(x)) / _etykietaDys;
            }
            else return 0;
        }
    }
}
