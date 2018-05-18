using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Functions;
using KSR2.Model.ParsingData;

namespace KSR2.Model.Fuzzy
{
    class Fuzzy1
    {
        private double[] _fuzzySet;
        public Fuzzy1(List<Person> people, int column)
        {
            _fuzzySet= new double[people.Count];
            if (column == 1)for (int i = 0; i < people.Count; i++)_fuzzySet[i]=people[i].age;
            if (column == 2) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].workclass;
            if (column == 3) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = people[i].salary;
            if (column == 4) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].education;
            if (column == 5) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].martialStatus;
            if (column == 6) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].occupation;
            if (column == 7) for (int i = 0; i < people.Count; i++) _fuzzySet[i] =(double)people[i].relationShip;
            if (column == 8) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].race;
            if (column == 9) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = (double)people[i].gender;
            if (column == 10) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = people[i].capitalGain;
            if (column == 11) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = people[i].capitalLoss;
            if (column == 12) for (int i = 0; i < people.Count; i++) _fuzzySet[i] = people[i].hoursPerWeek;
        }
        public double[] FuzzySet
        {
            get { return _fuzzySet; }
            set { _fuzzySet = value; }
        }
    }
}
