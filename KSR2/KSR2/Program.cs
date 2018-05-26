using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy;
using KSR2.Model.Fuzzy.Qualificators;
using KSR2.Model.LinguisticSum;
using KSR2.Model.ParsingData;

namespace KSR2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Label> lableList = new List<Label>();
            ReadData rd = new ReadData();
            List<Person> people = rd.GetDataPerson();

            #region Fuzzies
            Fuzzy1 ages = new Fuzzy1(people, 1);
            Fuzzy1 workClases = new Fuzzy1(people, 2);
            Fuzzy1 salaries = new Fuzzy1(people, 3);
            Fuzzy1 educations = new Fuzzy1(people, 4);
            Fuzzy1 martialStatuses = new Fuzzy1(people, 5);
            Fuzzy1 occupations = new Fuzzy1(people, 6);
            Fuzzy1 relationShips = new Fuzzy1(people, 7);
            Fuzzy1 races = new Fuzzy1(people, 8);
            Fuzzy1 genders = new Fuzzy1(people, 9);
            Fuzzy1 capitalGains = new Fuzzy1(people, 10);
            Fuzzy1 capitalLoses = new Fuzzy1(people, 11);
            Fuzzy1 hoursPerWeeks = new Fuzzy1(people, 12);
            #endregion
         
            #region Labels
            //Black Races
            Label raceLabel = new Label("Black", new TriangleFunc(4, 1), races);

            //Avarege Salaries
            Label avarageSalaries = new Label("with AveregeSalaries", new TrapezoidFunc(240000, 200000, 260000, 300000), salaries);

            //Hight Education
            Label hightEducation = new Label("with Hight Level Education ", new TriangleFunc(1, 2), educations);

            //avarageAge With triangle Function
            Label avarageAgeTriangle = new Label("Avarage AgeTria", new TriangleFunc(30, 10), ages);

            //avarageAge With trapezoid Function
            Label avarageAgeTrapezoid = new Label("Avarage AgeTra", new TrapezoidFunc(25, 20, 35, 40), ages);

            //Maried People
            Label merried = new Label("Maried ", new TriangleFunc(0, 1), martialStatuses);

            //Hight Education or avarage Salaries
            Label hightEducation_or_AvarageSalaries = new Label(hightEducation);
            hightEducation_or_AvarageSalaries.FuzzySubraction(avarageSalaries);

            //Black race and Avarage salaries
            Label blackRace_and_AvarageSalaries = new Label(raceLabel);
            blackRace_and_AvarageSalaries.FuzzySumm(avarageSalaries);

            //hight Education and Married
            Label hightEducation_And_Married = new Label(merried);
            hightEducation_And_Married.FuzzySumm(hightEducation);

            //hight Education or Married
            Label hightEducation_Or_Married = new Label(merried);
            hightEducation_Or_Married.FuzzySubraction(hightEducation);

            //(hight Education or Married)and black Race
            Label hightEducation_Or_Married_And_Black = new Label(hightEducation_Or_Married);
            hightEducation_Or_Married_And_Black.FuzzySumm(raceLabel);

            Label hightEducation_Or_Married_Or_Black = new Label(hightEducation_Or_Married);
            hightEducation_Or_Married_Or_Black.FuzzySubraction(raceLabel);
            #endregion


            #region Qualificators

            Qualificator raceQualificator = new Qualificator("Black", new TriangleFunc(4, 1), avarageSalaries,races);

            #endregion

            ReadQuantyficators rq = new ReadQuantyficators();
            List<Quantyficator> quantyficators = rq.read();
            // //   lableList.Add(raceLabel);
            //    lableList.Add(avarageSalaries);
            //     lableList.Add(hightEducation);
            //    lableList.Add(avarageAgeTriangle);
            //    lableList.Add(merried);
            //    lableList.Add(avarageAgeTrapezoid);
            lableList.Add(blackRace_and_AvarageSalaries);
            lableList.Add(hightEducation_And_Married);
            lableList.Add(hightEducation_or_AvarageSalaries);
            lableList.Add(hightEducation_Or_Married);
            lableList.Add(hightEducation_Or_Married_And_Black);
            lableList.Add(hightEducation_Or_Married_Or_Black);
            Linquistic l = new Linquistic(lableList, quantyficators);
            l.generateOutput();
            Console.ReadKey();
        }
    }
}
