using System.Collections.Generic;
using KSR2.Model.ParsingData;

namespace KSR2.Model.Fuzzy
{
    internal class Fuzzy1
    {
        public Fuzzy1(List<Person> people, int column)
        {
            FuzzySet = new double[people.Count];
            if (column == 1)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = people[i].Age;
            if (column == 2)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].Workclass;
            if (column == 3)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = people[i].Salary;
            if (column == 4)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].Education;
            if (column == 5)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].MartialStatus;
            if (column == 6)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].Occupation;
            if (column == 7)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].RelationShip;
            if (column == 8)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].Race;
            if (column == 9)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = (double) people[i].Gender;
            if (column == 10)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = people[i].CapitalGain;
            if (column == 11)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = people[i].CapitalLoss;
            if (column == 12)
                for (var i = 0; i < people.Count; i++)
                    FuzzySet[i] = people[i].HoursPerWeek;
        }

        public double[] FuzzySet { get; set; }
    }
}