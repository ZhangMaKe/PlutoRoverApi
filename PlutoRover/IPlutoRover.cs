using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover
{
    public interface IPlutoRover
    {
        Tuple<int, int, char> CurrentLocation { get; set; }
        void Move(char[] moveCommands);
        void MoveOnce(char moveCommand);
    }
}
