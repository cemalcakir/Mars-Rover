using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class Plateau
    {
        public int BorderX { get; }
        public int BorderY { get; }
        private List<Rover> Rovers;

        public Plateau(int[] limits)
        {
            BorderX = limits[0];
            BorderY = limits[1];
            Rovers = new List<Rover>();
        }

        public void AddRover(Rover rover)
        {
            Rovers.Add(rover);
        }

        public void ListRovers()
        {
            Rovers.ForEach(rover => Console.WriteLine(rover));
        }
    }
}
