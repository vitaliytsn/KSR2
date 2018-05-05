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
            List<Label> lableList= new List<Label>();
            ReadData rd = new ReadData();
            List<Person> people = rd.GetDataPerson();
            //Some Races
            double[] races= new double[people.Count];
            for (int i = 0; i < people.Count; i++)
            {
                races[i] = (int)people[i].race;
            }
            Label raceLabel = new Label("BlackRaces",new TriangleFunc(4,1),races);
           double ratio= raceLabel.getRatio();

            //Avarege Salaries
            double[] salaries = new double[people.Count];
            for (int i = 0; i < people.Count; i++)
            {
                salaries[i] = people[i].salary;
            }
            Label bestSalaries= new Label("with AveregeSalaries",new TriangleFunc(250000,50000),salaries);

            // Hight Education
            double[] education = new double[people.Count];
            for (int i = 0; i < people.Count; i++)
            {
                education[i] = (int)people[i].education;
            }
            Label hightEducation = new Label("with Hight Level Education ", new TriangleFunc(1, 2), education);
            hightEducation.FuzzySumm(bestSalaries);

            raceLabel.FuzzySumm(bestSalaries);
            lableList.Add(raceLabel);
            lableList.Add(hightEducation);
            lableList.Add(bestSalaries);
            Linquistic l = new Linquistic(lableList);
            l.generateOutput();
            Console.ReadKey();
        }
    }
}
