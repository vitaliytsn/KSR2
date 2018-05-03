using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model;
using KSR2.Model.Functions;
using KSR2.Model.ParsingData;

namespace KSR2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadData rd = new ReadData();
            List<Person> people = rd.GetDataPerson();
            Console.ReadKey();
        }
    }
}
