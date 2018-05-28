using System;

namespace KSR2.Model.Functions
{
    public class TriangleFunc : IFunction
    {
        private readonly double _etykietaDys;
        private readonly double _etykietNum;

        public TriangleFunc(double etykietaNum, double etykietaDys)
        {
            _etykietNum = etykietaNum;
            _etykietaDys = etykietaDys;
        }


        public TriangleFunc(TriangleFunc fun)
        {
            _etykietNum = fun._etykietNum;
            _etykietaDys = fun._etykietaDys;
        }

        public double Square()
        {
            return _etykietNum - _etykietaDys;
        }

        public double Distance()
        {
            return _etykietNum;
        }

        public double Count(double x)
        {
            if (x > _etykietNum - _etykietaDys && x < _etykietNum + _etykietaDys)
                if (x <= _etykietNum)
                    return Math.Abs(Math.Abs(x) - Math.Abs(_etykietNum) - _etykietaDys) / _etykietaDys;
                else
                    return Math.Abs(Math.Abs(_etykietNum) + _etykietaDys - Math.Abs(x)) / _etykietaDys;
            return 0;
        }
    }
}