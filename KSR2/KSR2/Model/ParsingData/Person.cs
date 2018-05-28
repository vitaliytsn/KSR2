using KSR2.Model.Enums;

namespace KSR2.Model.ParsingData
{
    public class Person
    {
        public double Age { get; set; }
        public WorkClass Workclass { get; set; }
        public int Salary { get; set; }

        public Education Education { get; set; }

        //nie wczytuje
        public MartialStatus MartialStatus { get; set; }
        public Occupation Occupation { get; set; }
        public RelationShip RelationShip { get; set; }
        public Rase Race { get; set; }
        public Sex Gender { get; set; }
        public int CapitalGain { get; set; }
        public int CapitalLoss { get; set; }

        public int HoursPerWeek { get; set; }
        //nie czytam dalej
    }
}