using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public class ObstacleLocation
    {
        public int XLocation { get; set; }
        public int YLocation { get; set; }

        public ObstacleLocation(int x, int y)
        {
            XLocation = x;
            YLocation = y;
        }
    }
}