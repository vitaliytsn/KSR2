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

            //avarageAge With trapezoid Function
            Label avarageAgeTrapezoid = new Label("Midle Age", new TrapezoidFunc(25, 20, 35, 40), ages);

            //Maried People
            Label merried = new Label("Maried ", new TriangleFunc(0, 1), martialStatuses);

            //Self mployed people
            Label selfEmployed = new Label("Self Employed", new TrapezoidFunc(0.5, 1.2, 1.8, 2.2), workClases);

            //gender = male
            Label males = new Label("Males", new TriangleFunc(1, 0.5), genders);

            //occupation= managers
             Label managers = new Label("Maneges", new TrapezoidFunc(2.5, 3.8, 4, 5.2), occupations);

            //Hight Education or avarage Salaries
            Label hightEducation_or_AvarageSalaries = new Label(hightEducation);
            hightEducation_or_AvarageSalaries.FuzzySubtraction(avarageSalaries);//sub

            //managers who has avarage salary
            Label managers_and_avarageSalaries = new Label(avarageSalaries);
            managers_and_avarageSalaries.FuzzySum(managers);

            //Hight Education or Black race
            Label hightEducation_or_Black = new Label(hightEducation);//sub
            hightEducation_or_Black.FuzzySubtraction(raceLabel);
            

            //Black race and Avarage salaries
            Label blackRace_and_AvarageSalaries = new Label(raceLabel);
            blackRace_and_AvarageSalaries.FuzzySum(avarageSalaries);

            //hight Education and Married
            Label hightEducation_And_Married = new Label(merried);
            hightEducation_And_Married.FuzzySum(hightEducation);

            //middle age and Avarage salaries
            Label middleAge_and_AvarageSalaries = new Label(avarageAgeTrapezoid);
            middleAge_and_AvarageSalaries.FuzzySum(avarageSalaries);

            //hight Education or Married
            Label hightEducation_Or_Married = new Label(merried);//sub
            hightEducation_Or_Married.FuzzySubtraction(hightEducation);

            //(hight Education or Married)and black Race
            Label hightEducation_Or_Married_And_Black = new Label(hightEducation_Or_Married);
            hightEducation_Or_Married_And_Black.FuzzySubtraction(raceLabel);

            Label hightEducation_Or_Married_Or_Black = new Label(hightEducation_Or_Married);//sub
            hightEducation_Or_Married_Or_Black.FuzzySubtraction(raceLabel);
            #endregion

            ReadQuantyficators rq = new ReadQuantyficators();
            List<Quantyficator> quantyficators = rq.read();

            #region Qualificators
            List<Qualificator> qualificators = new List<Qualificator>();
            Qualificator raceQualificator = new Qualificator("Which Are Black race", new TriangleFunc(4, 1), avarageSalaries, races);
            Qualificator hightEducation_Married = new Qualificator(" Who Has Hight Level Education ", new TriangleFunc(1, 2), merried, educations);
            Qualificator avarageAgeTriangle_AvarageSalaries = new Qualificator(" Has Middle Age ", new TriangleFunc(30, 10), hightEducation_Or_Married_Or_Black, ages);
            Qualificator managers_Avarage_Salaries = new Qualificator("who are Maneges ", new TrapezoidFunc(2.5, 3.8, 4, 5.2),avarageSalaries ,occupations);
            qualificators.Add(avarageAgeTriangle_AvarageSalaries);
            qualificators.Add(raceQualificator);
            qualificators.Add(hightEducation_Married);
            qualificators.Add(managers_Avarage_Salaries);
            Linquistic lq = new Linquistic(qualificators, quantyficators);
            lq.generateOutput();
            #endregion

            #region Labels
            lableList.Add(hightEducation_or_Black);
            lableList.Add(males);
            lableList.Add(managers);
            lableList.Add(selfEmployed);
            lableList.Add(raceLabel);
            lableList.Add(avarageSalaries);
            lableList.Add(hightEducation);
            lableList.Add(avarageAgeTrapezoid);
            lableList.Add(merried);
            lableList.Add(avarageAgeTrapezoid);

            lableList.Add(managers_and_avarageSalaries);
            lableList.Add(middleAge_and_AvarageSalaries);
            lableList.Add(blackRace_and_AvarageSalaries);
            lableList.Add(hightEducation_And_Married);
            lableList.Add(hightEducation_or_AvarageSalaries);
            lableList.Add(hightEducation_Or_Married);
           
            lableList.Add(hightEducation_Or_Married_Or_Black);
            
            Linquistic l = new Linquistic(lableList, quantyficators);
            l.generateOutput();
            #endregion

            Console.ReadKey();
        }
    }
}
