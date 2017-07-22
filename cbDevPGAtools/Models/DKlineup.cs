using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cbDevPGAtools.Models
{
    public class DKlineup
    {
        public List<int> Lineup { get; set; }

        public IList<Golfer> LineupGolfers { get; set; }

        public int LineupSalary { get; set; }

        public int LineupID { get; set; }

        

        public DKlineup()
        {
            LineupSalary = 0;
            LineupID = 0;
            List<Golfer> LineupGolfers = new List<Golfer>();
            List<int> Lineup = new List<int>();
            
        }
    }
}
