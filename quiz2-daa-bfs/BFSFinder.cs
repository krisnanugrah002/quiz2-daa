using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2_daa_bfs
{
    public static class BFSFinder
    {
        public static List<Flight> FindRouteBFS(Dictionary<string, List<Flight>> graph, string start, string end)
        {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var cameFrom = new Dictionary<string, Flight>();

            queue.Enqueue(start);
            visited.Add(start);
            cameFrom[start] = null;

            while (queue.Count > 0)
            {
                string currentAirport = queue.Dequeue();

                if (currentAirport == end)
                {
                    return ReconstructPath(cameFrom, start, end);
                }

                if (graph.ContainsKey(currentAirport))
                {
                    foreach (var flight in graph[currentAirport])
                    {
                        string nextAirport = flight.To;
                        if (!visited.Contains(nextAirport))
                        {
                            visited.Add(nextAirport);
                            queue.Enqueue(nextAirport);
                            cameFrom[nextAirport] = flight;
                        }
                    }
                }
            }
            return new List<Flight>();
        }

        private static List<Flight> ReconstructPath(Dictionary<string, Flight> cameFrom, string start, string end)
        {
            var path = new List<Flight>();
            string current = end;

            while (current != start && cameFrom.ContainsKey(current))
            {
                Flight flight = cameFrom[current];
                path.Add(flight);
                current = flight.From;
            }

            path.Reverse();

            if (path.Count > 0 && path[0].From == start)
            {
                return path;
            }

            return new List<Flight>();
        }
    }
}