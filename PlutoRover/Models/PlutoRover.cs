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
                if (!MoveOnce(moveCommand))
                {
                    return;
                }
                
            }
        }

        public bool MoveOnce(char moveCommand)
        {
            switch (moveCommand)
            {
                case 'F':
                case 'B':
                    var nextLocation = GetNextLocation(moveCommand);
                    if (Grid.ObstacleLocations.Any(o => o.XLocation == nextLocation.X && o.YLocation == nextLocation.Y))
                    {
                        return false;
                    }
                    MoveRover(moveCommand);
                    break;

                case 'L':
                case 'R':
                    TurnRover(moveCommand);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }

        private RoverLocation GetNextLocation(char moveCommand)
        {
            var nextLocation = new RoverLocation(CurrentLocation.X, CurrentLocation.Y, CurrentLocation.Direction);
            switch (CurrentLocation.Direction)
            {
                case 'N':
                    nextLocation.Y = moveCommand == 'F' ? CurrentLocation.Y + 1 : CurrentLocation.Y - 1;
                    break;

                case 'S':
                    nextLocation.Y = moveCommand == 'F' ? CurrentLocation.Y - 1 : CurrentLocation.Y + 1;
                    break;

                case 'E':
                    nextLocation.X = moveCommand == 'F' ? CurrentLocation.X + 1 : CurrentLocation.X - 1;
                    break;

                case 'W':
                    nextLocation.X = moveCommand == 'F' ? CurrentLocation.X - 1 : CurrentLocation.X + 1;
                    break;
            }

            return nextLocation;
        }

        private void MoveRover(char moveCommand)
        {
            if (moveCommand == 'F')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        MoveNorth();
                        break;
                    case 'S':
                        MoveSouth();
                        break;
                    case 'E':
                        MoveEast();
                        break;
                    case 'W':
                        MoveWest();
                        break;
                }
            }
            else if (moveCommand == 'B')
            {
                switch (CurrentLocation.Direction)
                {
                    case 'N':
                        MoveSouth();
                        break;
                    case 'S':
                        MoveNorth();
                        break;
                    case 'E':
                        MoveWest();
                        break;
                    case 'W':
                        MoveEast();
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Move Rover cannot move in direction of " + moveCommand);
            }
        }

        private void MoveEast()
        {
            CurrentLocation.X = CurrentLocation.X == 50 ? -50 : CurrentLocation.X + 1;
        }

        private void MoveWest()
        {
            CurrentLocation.X = CurrentLocation.X == -50 ? 50 : CurrentLocation.X - 1;
        }

        private void MoveNorth()
        {
            CurrentLocation.Y = CurrentLocation.Y == 50 ? -50 : CurrentLocation.Y + 1;
        }

        private void MoveSouth()
        {
            CurrentLocation.Y = CurrentLocation.Y == -50 ? 50 : CurrentLocation.Y - 1;
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