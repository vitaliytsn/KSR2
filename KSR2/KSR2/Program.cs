using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model;
using KSR2.Model.Functions;
using KSR2.Model.Fuzzy;
using KSR2.Model.ParsingData;

namespace KSR2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadData rd = new ReadData();
            List<Person> people = rd.GetDataPerson();
            double[] races= new double[people.Count];
            for (int i = 0; i < people.Count; i++)
            {
                races[i] = (int)people[i].race;
            }
            Label raceLabel = new Label("whiteRaces",new TriangleFunc(0,1.1),races);
           double ratio= raceLabel.getRatio();

            double[] salaries = new double[people.Count];
            for (int i = 0; i < people.Count; i++)
            {
                salaries[i] = people[i].salary;
            }
            Label bestSalaries= new Label("HightestSalaries",new TriangleFunc(250000,50000),salaries);
           
            Console.ReadKey();
        }
    }
}
