using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy;
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
            Fuzzy1 occupations = new Fuzzy1(people,6);
            Fuzzy1 relationShips = new Fuzzy1(people,7);
            Fuzzy1 races = new Fuzzy1(people,8);
            Fuzzy1 genders = new Fuzzy1(people,9);
            Fuzzy1 capitalGains = new Fuzzy1(people,10);
            Fuzzy1 capitalLoses = new Fuzzy1(people,11);
            Fuzzy1 hoursPerWeeks = new Fuzzy1(people,12);
            #endregion

            #region Labels
            //Black Races

            Label raceLabel = new Label("Black", new TriangleFunc(4, 1), races);
            //Avarege Salaries
            Label avarageSalaries = new Label("with AveregeSalaries", new TrapezoidFunc(240000, 200000, 260000, 300000), salaries);
            //Hight Education
            Label hightEducation = new Label("with Hight Level Education ", new TriangleFunc(1, 2), educations);
            //Hight Education or avarage Salaries
            Label hightEducation_or_AvarageSalaries=new Label(hightEducation);
            hightEducation_or_AvarageSalaries.FuzzySubraction(avarageSalaries);
            //Black race and Avarage salaries
            Label blackRace_and_AvarageSalaries = new Label(raceLabel);
            blackRace_and_AvarageSalaries.FuzzySumm(avarageSalaries);
            #endregion


            lableList.Add(raceLabel);

            lableList.Add(blackRace_and_AvarageSalaries);
            lableList.Add(hightEducation_or_AvarageSalaries);

            lableList.Add(avarageSalaries);
            Linquistic l = new Linquistic(lableList);
            l.generateOutput();
            Console.ReadKey();
        }
    }
}
