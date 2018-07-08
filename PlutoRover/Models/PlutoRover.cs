using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public class PlutoRover : IPlutoRover
    {
        public Tuple<int, int, char> CurrentLocation { get; set; }
        public void Move(char[] moveCommands)
        {
            throw new NotImplementedException();
        }

        public void MoveOnce(char moveCommand)
        {
            throw new NotImplementedException();
        }
    }
}