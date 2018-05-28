using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy.Qualificators
{
    public class Quantyficator
    {
        public IFunction Function { get; set; }

        public string LablelName { get; set; }

        public double Count(double d)
        {
            return Function.Count(d);
        }

        public double CardinalNumber()
        {
            return Function.Distance();
        }
    }
}