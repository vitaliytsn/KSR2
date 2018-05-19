using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;

namespace KSR2.Model.Fuzzy
{
    class Label
    {
        //sumaryzator
        private List<Label> _insideLabels;
        private string _labelName;
        private Fuzzy1 _fuzz;
        private IFunction _function;
        private double[] _membershipRatio;

        public string LabelName
        {
            get { return _labelName; }
        }
        public Fuzzy1 Fuzzy
        {
            get
            {
                return _fuzz; 

            }
        }
        public IFunction Function
        {
            get { return _function;}
            set { _function = value; }
        }
        public double[] MembershipRatio
        {
            get { return _membershipRatio; }
            set { _membershipRatio = value; }
        }
        public Label(string label, IFunction func,Fuzzy1 fuzzy)
        {
            _insideLabels= new List<Label>();
            _labelName = label;
            _fuzz = fuzzy;
            _function = func;
            _membershipRatio = new double[_fuzz.FuzzySet.Length];
            for (int i = 0; i < _fuzz.FuzzySet.Length; i++)
            {
                _membershipRatio[i] = membership(_fuzz.FuzzySet[i]);
            }
        }

        public Label(Label label)
        {
            this._insideLabels= new List<Label>();
            foreach (var lab in label._insideLabels)
            {
                this._insideLabels.Add(new Label(lab));
            }
            this._labelName = label._labelName;
            this._function = label._function;
            this._fuzz = label._fuzz;
            this._membershipRatio =new double[Fuzzy.FuzzySet.Length];
            for (int i=0;i<label._membershipRatio.Length;i++)
            {
                _membershipRatio[i]=label._membershipRatio[i];
            }
          
        }
        public double membership(double x)
        {
            return _function.count(x);
        }

        public void FuzzySumm(Label summ)//czyli and - T norma
        {
            _insideLabels.Add(summ);
            this._labelName = this._labelName +" and "+ summ._labelName;
            for (int i=0;i<_membershipRatio.Length;i++)
            {
                if(summ._membershipRatio[i]< _membershipRatio[i])
                    _membershipRatio[i] = summ._membershipRatio[i];
            }
        }

        public void FuzzySubraction(Label summ) //czyli or S norma
        {
            _insideLabels.Add(summ);
            this._labelName = this._labelName + " or " + summ._labelName;
            for (int i = 0; i < _membershipRatio.Length; i++)
            {
                if (summ._membershipRatio[i] > _membershipRatio[i])
                    _membershipRatio[i] = summ._membershipRatio[i];
            }
        }

        public double degreeOfImprecision1()
        {
            double t = cardinalNumber();
            foreach (var label in _insideLabels)
            {
                t *= label.cardinalNumber();
            }
            t = Math.Pow(t,(double)1/(_insideLabels.Count + 1));
            return t;
        }
        public  double cardinalNumber()
        {
            double cardinal = 0;
            foreach (var variable in _membershipRatio)
            {
                if(variable>0)
                cardinal += 1;
            }
            return cardinal/Fuzzy.FuzzySet.Length;
        }
    }
}
