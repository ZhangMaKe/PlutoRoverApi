using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRover.Models
{
    public class PlutoRover : IPlutoRover
    {
        public Tuple<int, int, char> CurrentLocation { get; set; } = new Tuple<int, int, char>(0, 0, 'N');
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