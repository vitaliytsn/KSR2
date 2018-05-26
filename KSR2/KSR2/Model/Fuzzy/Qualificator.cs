using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    class Qualificator
    {
        private List<Qualificator> _insideQualificators;
        private string _qualificatorName;
        private Label _label;
        private IFunction _function;
        private double[] _membershipRatio;
        private Fuzzy1 _fuzz;

        public Qualificator(string name, IFunction func, Label label,Fuzzy1 fuzz)
        {
            _insideQualificators = new List<Qualificator>();
            _qualificatorName = name;
            _label = label;
            _function = func;
            this._fuzz = fuzz;
            _membershipRatio = new double[_label.Fuzzy.FuzzySet.Length];
            for (int i = 0; i < _label.Fuzzy.FuzzySet.Length; i++)
            {
                _membershipRatio[i] = membership(fuzz.FuzzySet[i]);
            }

            for (int i = 0; i < _membershipRatio.Length; i++)
            {
                if (_membershipRatio[i] > _label.MembershipRatio[i])
                    _membershipRatio[i] = _label.MembershipRatio[i];
            }
        }






        public string QualificatorName
        {
            get { return _qualificatorName; }
        }
        public Label Labell
        {
            get
            {
                return _label;

            }
        }
        public IFunction Function
        {
            get { return _function; }
            set { _function = value; }
        }
        public double[] MembershipRatio
        {
            get { return _membershipRatio; }
            set { _membershipRatio = value; }
        }
        public double membership(double x)
        {
            return _function.count(x);
        }
        public double cardinalNumber()
        {
            double cardinal = 0;
            foreach (var variable in _membershipRatio)
            {
                if (variable > 0)
                    cardinal += 1;
            }
            return cardinal / _label.MembershipRatio.Length;
        }
    }
}
