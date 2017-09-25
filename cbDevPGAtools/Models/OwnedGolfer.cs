using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cbDevPGAtools.Models
{
    public class OwnedGolfer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int DKtourneyID { get; set; }

        public int GolferID { get; set; }

        public int projOwnedGolfer { get; set; }

        public double Ownership { get; set; }

        public int Salary { get; set; }

        public int Tagged { get; set; }

        public int Sit { get; set; }

        public int Start { get; set; }


    }
}
