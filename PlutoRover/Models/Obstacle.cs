using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public class Obstacle
    {
        public Tuple<int, int> Location { get; set; }

        public Obstacle(Tuple<int, int> location)
        {
            Location = location;
        }
    }
}