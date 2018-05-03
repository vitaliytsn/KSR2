using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Enums;

namespace KSR2.Model.ParsingData
{
    class ReadData
    {
        public List<Person> GetDataPerson()
        {
            //Gender,Weight,Height,ShirtSize,FootSize,Age,Race
            List<Person> people =new List<Person>();
            string[] lines = System.IO.File.ReadAllLines(@"database.txt");



            
            for (int q=0;q<lines.Length;q++)
            {
                Person newPerson= new Person();
                int i = 0;
                string s = getNextWord(ref i,lines[q]);
               
                if (s=="Female")
                newPerson.gender = Gender.Female;
                else newPerson.gender = Gender.Male;
                 
                
                s= getNextWord(ref i, lines[q]);
                newPerson.weight = Convert.ToDouble(s);

                s = getNextWord(ref i, lines[q]);
                newPerson.height = Convert.ToDouble(s);


                s = getNextWord(ref i, lines[q]);
                if(s=="S")
                newPerson.shirtSize = ShirtSize.S;
                if (s == "M")
                    newPerson.shirtSize = ShirtSize.M;
                if (s == "L")
                    newPerson.shirtSize = ShirtSize.L;
                if (s == "XS")
                    newPerson.shirtSize = ShirtSize.XS;
                if (s == "XM")
                    newPerson.shirtSize = ShirtSize.XM;
                if (s == "XL")
                    newPerson.shirtSize = ShirtSize.XL;

                s = getNextWord(ref i, lines[q]);
                newPerson.footSize = Convert.ToDouble(s);

                s = getNextWord(ref i, lines[q]);
                newPerson.age = Convert.ToDouble(s);
                s = getNextWord(ref i, lines[q]);
                if(s== "Chineese")
                newPerson.race = Rase.Chinese;
                if (s == "Korean")
                    newPerson.race = Rase.Korean;
                if (s == "Mexican")
                    newPerson.race = Rase.Mexican;
                if (s == "Filipino")
                    newPerson.race = Rase.Filipino;
                if (s == "Europinian")
                    newPerson.race = Rase.Europinian;
                /*  if (lines[q].Length - 2 < i)
                  {
                      Random rnd = new Random();
                      int rand;
                      if (newPerson.shirtSize == ShirtSize.S || newPerson.shirtSize == ShirtSize.M)
                          rand = rnd.Next(2);
                      else
                      {
                          rand = rnd.Next(5);
                      }

                      if (rand==0)
                          lines[q] += "Korean";
                      if (rand==1)
                          lines[q] += "Chineese";
                      if (rand==2)
                          lines[q] += "Mexican";
                      if (rand==3)
                          lines[q] += "Filipino";
                      if (rand==4)
                          lines[q] += "Europinian";
                  }*/

                people.Add(newPerson);
            }
            System.IO.File.WriteAllLines(@"database.txt", lines);
            return people;
        }

        public string getNextWord(ref int i,string line)
        {
            string s = "";
            while (line[i] == ' ') i++;
            while (i<line.Length && line[i] != ',') { s += line[i]; i++; }

            i++;
            return s;
        }
    }
}
