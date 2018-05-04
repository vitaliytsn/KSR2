using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR2.Model.Enums;

namespace KSR2.Model.ParsingData
{
   public class Person
    {
        public double age { get; set; }
        public WorkClass workclass { get; set; }
        public int salary { get; set; }
        public Education education { get; set; }
        //nie wczytuje
        public MartialStatus martialStatus { get; set; }
        public Occupation occupation{get; set; }
        public RelationShip relationShip { get; set; }
        public Rase race { get; set; }
        public Sex gender { get; set; }
        public int capitalGain { get; set; }
        public int capitalLoss { get; set; }
        public int hoursPerWeek { get; set; }
        //nie czytam dalej
    }
}
