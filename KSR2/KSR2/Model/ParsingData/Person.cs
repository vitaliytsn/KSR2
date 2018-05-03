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
        public Gender gender { get; set; }
        public double weight { get; set; }

        public double height { get; set; }

        public ShirtSize shirtSize { get; set; }

        public double footSize { get; set; }

        public double age { get; set; }

        public Rase race { get; set; }

    }
}
