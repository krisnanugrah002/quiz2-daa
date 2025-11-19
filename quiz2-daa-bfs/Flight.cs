using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2_daa_bfs
{
    public record Flight
    {
        public string From { get; init; }
        public string To { get; init; }

        public int Duration { get; init; }

        public string FlightId { get; init; }


        public Flight(string from, string to, int duration, string flightId)
        {
            From = from;
            To = to;
            Duration = duration;
            FlightId = flightId; 
        }
    }
}
