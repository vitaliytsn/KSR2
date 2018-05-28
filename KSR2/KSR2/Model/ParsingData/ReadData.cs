using System;
using System.Collections.Generic;
using System.IO;
using KSR2.Model.Enums;

namespace KSR2.Model.ParsingData
{
    internal class ReadData
    {
        public List<Person> GetDataPerson()
        {
            //Gender,Weight,Height,ShirtSize,FootSize,Age,Race
            var people = new List<Person>();
            var lines = File.ReadAllLines(@"database.txt");

            for (var q = 0; q < lines.Length; q++)
            {
                var newPerson = new Person();
                var i = 0;
                var s = GetNextWord(ref i, lines[q]);
                newPerson.Age = Convert.ToInt32(s);

                s = GetNextWord(ref i, lines[q]);
                if (s == "Private")
                    newPerson.Workclass = WorkClass.Private;
                if (s == "Self-emp-not-inc")
                    newPerson.Workclass = WorkClass.SelfEmpNotInc;
                if (s == "Self-emp-inc")
                    newPerson.Workclass = WorkClass.SelfEmpInc;
                if (s == "Federal-gov")
                    newPerson.Workclass = WorkClass.FederalGov;
                if (s == "Local-gov")
                    newPerson.Workclass = WorkClass.LocalGov;
                if (s == "State-gov")
                    newPerson.Workclass = WorkClass.StateGov;
                if (s == "Without-pay")
                    newPerson.Workclass = WorkClass.WithoutPay;
                if (s == "Never-worked")
                    newPerson.Workclass = WorkClass.NeverWorked;

                s = GetNextWord(ref i, lines[q]);
                newPerson.Salary = Convert.ToInt32(s);

                s = GetNextWord(ref i, lines[q]);

                if (s == "Bachelors") newPerson.Education = Education.Bachelors;
                if (s == "Some-college") newPerson.Education = Education.SomeCollege;
                if (s == "11th") newPerson.Education = Education.Eleventh;
                if (s == "HS-grad") newPerson.Education = Education.HsGrad;
                if (s == "Prof-school") newPerson.Education = Education.ProfSchool;
                if (s == "Assoc-acdm") newPerson.Education = Education.AssocAcdm;
                if (s == "Assoc-voc") newPerson.Education = Education.AssocVoc;
                if (s == "9th") newPerson.Education = Education.Nineth;
                if (s == "7th-8th") newPerson.Education = Education.SeventhEighth;
                if (s == "12th") newPerson.Education = Education.Twelveth;
                if (s == "Masters") newPerson.Education = Education.Masters;
                if (s == "1st-4th") newPerson.Education = Education.FirsthFourth;
                if (s == "10th") newPerson.Education = Education.Tenth;
                if (s == "Doctorate") newPerson.Education = Education.Doctorate;
                if (s == "5th-6th") newPerson.Education = Education.FirsthFourth;
                if (s == "Preschool") newPerson.Education = Education.Preschool;
                s = GetNextWord(ref i, lines[q]);
                //Martial Status

                s = GetNextWord(ref i, lines[q]);
                if (s == "Married-civ-spouse") newPerson.MartialStatus = MartialStatus.MarriedCivSpouse;
                if (s == "Divorced") newPerson.MartialStatus = MartialStatus.Divorced;
                if (s == "Never-married") newPerson.MartialStatus = MartialStatus.NeverMarried;
                if (s == "Separated") newPerson.MartialStatus = MartialStatus.Separated;
                if (s == "Widowed") newPerson.MartialStatus = MartialStatus.Widowed;
                if (s == "Married-spouse-absent") newPerson.MartialStatus = MartialStatus.MarriedSpouseAbsent;
                if (s == "Married-AF-spouse") newPerson.MartialStatus = MartialStatus.MarriedAfSpouse;

                //Occupation
                //, ,, , , , , , , , , , , .
                s = GetNextWord(ref i, lines[q]);
                if (s == "Tech-support") newPerson.Occupation = Occupation.TechSupport;
                if (s == "Craft-repair") newPerson.Occupation = Occupation.CraftRepair;
                if (s == "Other-service") newPerson.Occupation = Occupation.OtherService;
                if (s == "Sales") newPerson.Occupation = Occupation.Sales;
                if (s == "Exec-managerial") newPerson.Occupation = Occupation.ExecManagerial;
                if (s == "Prof-specialty") newPerson.Occupation = Occupation.ProfSpecialty;
                if (s == "Handlers-cleaners") newPerson.Occupation = Occupation.HandlersCleaners;
                if (s == "Machine-op-inspct") newPerson.Occupation = Occupation.MachineOpInspct;
                if (s == "Adm-clerical") newPerson.Occupation = Occupation.AdmClerical;
                if (s == "Farming-fishing") newPerson.Occupation = Occupation.FarmingFishing;
                if (s == "Transport-moving") newPerson.Occupation = Occupation.TransportMoving;
                if (s == "Priv-house-serv") newPerson.Occupation = Occupation.PrivHouseServ;
                if (s == "Protective-serv") newPerson.Occupation = Occupation.ProtectiveServ;
                if (s == "Armed-Forces") newPerson.Occupation = Occupation.ArmedForces;


                s = GetNextWord(ref i, lines[q]);

                if (s == "Wife") newPerson.RelationShip = RelationShip.Wife;
                if (s == "Own-child") newPerson.RelationShip = RelationShip.OwnChild;
                if (s == "Other-relative") newPerson.RelationShip = RelationShip.OtherRelative;
                if (s == "Husband") newPerson.RelationShip = RelationShip.Husband;
                if (s == "Not-in-family") newPerson.RelationShip = RelationShip.NotInFamily;
                if (s == "Unmarried") newPerson.RelationShip = RelationShip.Unmarried;

                s = GetNextWord(ref i, lines[q]);

                if (s == "White") newPerson.Race = Rase.White;
                if (s == "Asian-Pac-Islander") newPerson.Race = Rase.AsianPacIslander;
                if (s == "Amer-Indian-Eskimo") newPerson.Race = Rase.AmerIndianEskimo;
                if (s == "Other") newPerson.Race = Rase.Other;
                if (s == "Black") newPerson.Race = Rase.Black;


                s = GetNextWord(ref i, lines[q]);
                if (s == "Female")
                    newPerson.Gender = Sex.Female;
                else newPerson.Gender = Sex.Male;

                s = GetNextWord(ref i, lines[q]);
                newPerson.CapitalGain = Convert.ToInt32(s);
                s = GetNextWord(ref i, lines[q]);
                newPerson.CapitalLoss = Convert.ToInt32(s);
                s = GetNextWord(ref i, lines[q]);
                newPerson.HoursPerWeek = Convert.ToInt32(s);

                people.Add(newPerson);
            }

            File.WriteAllLines(@"database.txt", lines);
            return people;
        }

        public string GetNextWord(ref int i, string line)
        {
            var s = "";
            while (line[i] == ' ') i++;
            while (i < line.Length && line[i] != ',')
            {
                s += line[i];
                i++;
            }

            i++;
            return s;
        }
    }
}