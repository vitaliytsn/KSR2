using System;
using System.Collections.Generic;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy;
using KSR2.Model.LinguisticSum;
using KSR2.Model.ParsingData;

namespace KSR2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lableList = new List<Label>();
            var rd = new ReadData();
            var people = rd.GetDataPerson();

            #region Fuzzies

            var ages = new Fuzzy1(people, 1);
            var workClases = new Fuzzy1(people, 2);
            var salaries = new Fuzzy1(people, 3);
            var educations = new Fuzzy1(people, 4);
            var martialStatuses = new Fuzzy1(people, 5);
            var occupations = new Fuzzy1(people, 6);
            var relationShips = new Fuzzy1(people, 7);
            var races = new Fuzzy1(people, 8);
            var genders = new Fuzzy1(people, 9);
            var capitalGains = new Fuzzy1(people, 10);
            var capitalLoses = new Fuzzy1(people, 11);
            var hoursPerWeeks = new Fuzzy1(people, 12);

            #endregion

            #region Labels

            //Black Races
            var raceLabel = new Label("Black", new TriangleFunc(4, 1), races);

            //Avarege Salaries
            var avarageSalaries = new Label("with AveregeSalaries", new TrapezoidFunc(240000, 200000, 260000, 300000),
                salaries);

            //Hight Education
            var hightEducation = new Label("with Hight Level Education ", new TriangleFunc(1, 2), educations);

            //avarageAge With trapezoid Function
            var avarageAgeTrapezoid = new Label("Midle Age", new TrapezoidFunc(25, 20, 35, 40), ages);

            //Maried People
            var merried = new Label("Maried ", new TriangleFunc(0, 1), martialStatuses);

            //Self mployed people
            var selfEmployed = new Label("Self Employed", new TrapezoidFunc(0.5, 1.2, 1.8, 2.2), workClases);

            //gender = male
            var males = new Label("Males", new TriangleFunc(1, 0.5), genders);

            //occupation= managers
            var managers = new Label("Maneges", new TrapezoidFunc(2.5, 3.8, 4, 5.2), occupations);

            //Hight Education or avarage Salaries
            var hightEducationOrAvarageSalaries = new Label(hightEducation);
            hightEducationOrAvarageSalaries.FuzzySubtraction(avarageSalaries); //sub

            //managers who has avarage salary
            var managersAndAvarageSalaries = new Label(avarageSalaries);
            managersAndAvarageSalaries.FuzzySum(managers);

            //Hight Education or Black race
            var hightEducationOrBlack = new Label(hightEducation); //sub
            hightEducationOrBlack.FuzzySubtraction(raceLabel);


            //Black race and Avarage salaries
            var blackRaceAndAvarageSalaries = new Label(raceLabel);
            blackRaceAndAvarageSalaries.FuzzySum(avarageSalaries);

            //hight Education and Married
            var hightEducationAndMarried = new Label(merried);
            hightEducationAndMarried.FuzzySum(hightEducation);

            //middle age and Avarage salaries
            var middleAgeAndAvarageSalaries = new Label(avarageAgeTrapezoid);
            middleAgeAndAvarageSalaries.FuzzySum(avarageSalaries);

            //hight Education or Married
            var hightEducationOrMarried = new Label(merried); //sub
            hightEducationOrMarried.FuzzySubtraction(hightEducation);

            //(hight Education or Married)and black Race
            var hightEducationOrMarriedAndBlack = new Label(hightEducationOrMarried);
            hightEducationOrMarriedAndBlack.FuzzySubtraction(raceLabel);

            var hightEducationOrMarriedOrBlack = new Label(hightEducationOrMarried); //sub
            hightEducationOrMarriedOrBlack.FuzzySubtraction(raceLabel);

            #endregion

            var rq = new ReadQuantyficators();
            var quantyficators = rq.Read();

            #region Qualificators

            var qualificators = new List<Qualificator>();
            var raceQualificator =
                new Qualificator("Which Are Black race", new TriangleFunc(4, 1), avarageSalaries, races);
            var hightEducationMarried = new Qualificator(" Who Has Hight Level Education ", new TriangleFunc(1, 2),
                merried, educations);
            var avarageAgeTriangleAvarageSalaries = new Qualificator(" Has Middle Age ", new TriangleFunc(30, 10),
                hightEducationOrMarriedOrBlack, ages);
            var managersAvarageSalaries = new Qualificator("who are Maneges ", new TrapezoidFunc(2.5, 3.8, 4, 5.2),
                avarageSalaries, occupations);
            qualificators.Add(avarageAgeTriangleAvarageSalaries);
            qualificators.Add(raceQualificator);
            qualificators.Add(hightEducationMarried);
            qualificators.Add(managersAvarageSalaries);
            var lq = new Linquistic(qualificators, quantyficators);
            lq.GenerateOutput();

            #endregion

            #region Labels

            lableList.Add(hightEducationOrBlack);
            lableList.Add(males);
            lableList.Add(managers);
            lableList.Add(selfEmployed);
            lableList.Add(raceLabel);
            lableList.Add(avarageSalaries);
            lableList.Add(hightEducation);
            lableList.Add(avarageAgeTrapezoid);
            lableList.Add(merried);
            lableList.Add(avarageAgeTrapezoid);

            lableList.Add(managersAndAvarageSalaries);
            lableList.Add(middleAgeAndAvarageSalaries);
            lableList.Add(blackRaceAndAvarageSalaries);
            lableList.Add(hightEducationAndMarried);
            lableList.Add(hightEducationOrAvarageSalaries);
            lableList.Add(hightEducationOrMarried);

            lableList.Add(hightEducationOrMarriedOrBlack);

            var l = new Linquistic(lableList, quantyficators);
            l.GenerateOutput();

            #endregion

            Console.ReadKey();
        }
    }
}