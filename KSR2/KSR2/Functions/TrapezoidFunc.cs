namespace KSR2.Model.Functions
{
    public class TrapezoidFunc : IFunction
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        private readonly double _d;
        //      a       c

        //b                  d
        public TrapezoidFunc(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double Square()
        {
            return (_a - _b) * (_d - _c);
        }

        public double Distance()
        {
            return _d - _b;
        }

        public double Count(double x)
        {
            if (x >= _a && x <= _c) return 1;
            if (x > _b && x < _a) return (x - _b) / (_a - _b);
            if (x > _c && x < _d) return (_d - x) / (_d - _c);
            return 0;
        }
    }
}