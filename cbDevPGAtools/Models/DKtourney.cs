using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cbDevPGAtools.Models
{
    public class DKtourney
    {
        
            public int ID { get; set; }

            public string Name { get; set; }

            public IList<Golfer> Participants { get; set; }


            public DKtourney()
            {
                List<Golfer> Participants = new List<Golfer>();
            }

            public DKtourney(IEnumerable<Golfer> golfers)
            {
                Participants = new List<Golfer>();

                foreach (var golfer in golfers)
                {
                    Participants.Add(golfer);
                }
            }
        
    }

}
