using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public static class Grid
    {
        public static int Height { get; set; } = 100;
        public static int Width { get; set; } = 100;

        public static List<ObstacleLocation> ObstacleLocations { get; set; } = new List<ObstacleLocation>();
    }
}