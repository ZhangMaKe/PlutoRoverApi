using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public class RoverLocation
    {
        public RoverLocation()
        {
            
        }

        public RoverLocation(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public char Direction { get; set; } = 'N';
    }
}