using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace PlutoRover.Models
{
    public class PlutoRover : IPlutoRover
    {
        public RoverLocation CurrentLocation { get; set; } = new RoverLocation();
        public void Move(char[] moveCommands)
        {
            foreach (var moveCommand in moveCommands)
            {
                MoveOnce(moveCommand);
            }
        }

        public void MoveOnce(char moveCommand)
        {
            switch (moveCommand)
            {
                case 'F':
                case 'B':
                    MoveRover(moveCommand);
                    break;

                case 'L':
                case 'R':
                    TurnRover(moveCommand);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveRover(char moveCommand)
        {
            if (moveCommand == 'F')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        CurrentLocation.Y++;
                        break;
                    case 'S':
                        CurrentLocation.Y--;
                        break;
                    case 'E':
                        CurrentLocation.X++;
                        break;
                    case 'W':
                        CurrentLocation.X--;
                        break;
                }
            }
            else if(moveCommand == 'B')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        CurrentLocation.Y--;
                        break;
                    case 'S':
                        CurrentLocation.Y++;
                        break;
                    case 'E':
                        CurrentLocation.X--;
                        break;
                    case 'W':
                        CurrentLocation.X++;
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Move Rover cannot move in direction of " + moveCommand);
            }
        }

        private void TurnRover(char moveCommand)
        {
            if (moveCommand == 'R')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        CurrentLocation.Direction = 'E';
                        break;
                    case 'S':
                        CurrentLocation.Direction = 'W';
                        break;
                    case 'E':
                        CurrentLocation.Direction = 'S';
                        break;
                    case 'W':
                        CurrentLocation.Direction = 'N';
                        break;
                }
            }
            else if (moveCommand == 'L')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        CurrentLocation.Direction = 'W';
                        break;
                    case 'S':
                        CurrentLocation.Direction = 'E';
                        break;
                    case 'E':
                        CurrentLocation.Direction = 'N';
                        break;
                    case 'W':
                        CurrentLocation.Direction = 'S';
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Turn Rover cannot move in direction of " + moveCommand);
            }
            
        }
    }
}