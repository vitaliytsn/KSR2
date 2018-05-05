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
                newPerson.age = Convert.ToInt32(s);

                s = getNextWord(ref i, lines[q]);
                if(s== "Private")
                newPerson.workclass = WorkClass.Private;
                if (s == "Self-emp-not-inc")
                    newPerson.workclass = WorkClass.Self_Emp_Not_Inc;
                if (s == "Self-emp-inc")
                    newPerson.workclass = WorkClass.Self_Emp_inc;
                if (s == "Federal-gov")
                    newPerson.workclass = WorkClass.Federal_gov;
                if (s == "Local-gov")
                    newPerson.workclass = WorkClass.Local_gov;
                if (s == "State-gov")
                    newPerson.workclass = WorkClass.State_gov;
                if (s == "Without-pay")
                    newPerson.workclass = WorkClass.Without_pay;
                if (s == "Never-worked")
                    newPerson.workclass = WorkClass.Never_worked;

                s = getNextWord(ref i, lines[q]);
                newPerson.salary = Convert.ToInt32(s);

                s = getNextWord(ref i, lines[q]);

                if (s == "Bachelors") newPerson.education = Education.Bachelors;
                if (s == "Some-college") newPerson.education = Education.Some_College;
                if (s == "11th") newPerson.education = Education.Eleventh;
                if (s == "HS-grad") newPerson.education = Education.HS_grad;
                if (s == "Prof-school") newPerson.education = Education.Prof_school;
                if (s == "Assoc-acdm") newPerson.education = Education.Assoc_acdm;
                if (s == "Assoc-voc") newPerson.education = Education.Assoc_voc;
                if (s == "9th") newPerson.education = Education.Nineth;
                if (s == "7th-8th") newPerson.education = Education.Seventh_Eighth;
                if (s == "12th") newPerson.education = Education.Twelveth;
                if (s == "Masters") newPerson.education = Education.Masters;
                if (s == "1st-4th") newPerson.education = Education.Firsth_Fourth;
                if (s == "10th") newPerson.education = Education.Tenth;
                if (s == "Doctorate") newPerson.education = Education.Doctorate;
                if (s == "5th-6th") newPerson.education = Education.Firsth_Fourth;
                if (s == "Preschool") newPerson.education = Education.Preschool;
                s = getNextWord(ref i, lines[q]);
                //Martial Status

                s = getNextWord(ref i, lines[q]);
                if (s == "Married-civ-spouse") newPerson.martialStatus = MartialStatus.Married_civ_spouse;
                if (s == "Divorced") newPerson.martialStatus = MartialStatus.Divorced;
                if (s == "Never-married") newPerson.martialStatus = MartialStatus.Never_married;
                if (s == "Separated") newPerson.martialStatus = MartialStatus.Separated;
                if (s == "Widowed") newPerson.martialStatus = MartialStatus.Widowed;
                if (s == "Married-spouse-absent") newPerson.martialStatus = MartialStatus.Married_spouse_absent;
                if (s == "Married-AF-spouse") newPerson.martialStatus = MartialStatus.Married_AF_spouse;

                //Occupation
                //, ,, , , , , , , , , , , .
                s = getNextWord(ref i, lines[q]);
                if(s== "Tech-support") newPerson.occupation = Occupation.Tech_support;
                if (s == "Craft-repair") newPerson.occupation = Occupation.Craft_repair;
                if (s == "Other-service") newPerson.occupation = Occupation.Other_service;
                if (s == "Sales") newPerson.occupation = Occupation.Sales;
                if (s == "Exec-managerial") newPerson.occupation = Occupation.Exec_managerial;
                if (s == "Prof-specialty") newPerson.occupation = Occupation.Prof_specialty;
                if (s == "Handlers-cleaners") newPerson.occupation = Occupation.Handlers_cleaners;
                if (s == "Machine-op-inspct") newPerson.occupation = Occupation.Machine_op_inspct;
                if (s == "Adm-clerical") newPerson.occupation = Occupation.Adm_clerical;
                if (s == "Farming-fishing") newPerson.occupation = Occupation.Farming_fishing;
                if (s == "Transport-moving") newPerson.occupation = Occupation.Transport_moving;
                if (s == "Priv-house-serv") newPerson.occupation = Occupation.Priv_house_serv;
                if (s == "Protective-serv") newPerson.occupation = Occupation.Protective_serv;
                if (s == "Armed-Forces") newPerson.occupation = Occupation.Armed_Forces;


                s = getNextWord(ref i, lines[q]);
               
                if(s=="Wife")newPerson.relationShip = RelationShip.Wife;
                if (s == "Own-child") newPerson.relationShip = RelationShip.Own_child;
                if (s == "Other-relative") newPerson.relationShip = RelationShip.Other_relative;
                if (s == "Husband") newPerson.relationShip = RelationShip.Husband;
                if (s == "Not-in-family") newPerson.relationShip = RelationShip.Not_in_family;
                if (s == "Unmarried") newPerson.relationShip = RelationShip.Unmarried;

                s = getNextWord(ref i, lines[q]);
               
              if(s== "White")  newPerson.race = Rase.White;
                if (s == "Asian-Pac-Islander") newPerson.race = Rase.Asian_Pac_Islander;
                if (s == "Amer-Indian-Eskimo") newPerson.race = Rase.Amer_Indian_Eskimo;
                if (s == "Other") newPerson.race = Rase.Other;
                if (s == "Black") newPerson.race = Rase.Black;

             
                s = getNextWord(ref i, lines[q]);
                if (s=="Female")
                newPerson.gender = Sex.Female;
                else newPerson.gender = Sex.Male;

                s = getNextWord(ref i, lines[q]);
                newPerson.capitalGain = Convert.ToInt32(s);
                s = getNextWord(ref i, lines[q]);
                newPerson.capitalLoss = Convert.ToInt32(s);
                s = getNextWord(ref i, lines[q]);
                newPerson.hoursPerWeek = Convert.ToInt32(s);

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
