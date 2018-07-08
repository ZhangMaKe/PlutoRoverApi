using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Controllers;
using PlutoRover.Models;

namespace PlutoRover.Tests.Controllers
{
    [TestClass]
    public class PlutoRoverControllerTest
    {
        [TestMethod]
        public void MoveOneSpaceForward_LocationAfterMoveIs01N()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new [] {'F'};

            //Act

            roverController.MoveRover(moveCommands);

            //Assert

            var expectedPosition = new RoverLocation(0, 1, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceBackwards_LocatioAfterMoveIs0Minus1N()
        {
            //Arrange

            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'B' };

            //Act

            roverController.MoveRover(moveCommands);

            //Assert

            var expectedPosition = new RoverLocation(0, -1, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);

        }

        [TestMethod]
        public void MoveTwoStepsForwards_LocationAfterMoveIs12N()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'F', 'F' };

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(0, 2, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceForwardTurnRight_LocationAfterMoveIs01E()
        {
            //Arrange

            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'F', 'R' };

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(0, 1, 'E');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void TurnRightMoveOneSpaceForward_LocationAfterMoveIs10E()
        {
            //Arrange

            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'R', 'F' };

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(1, 0, 'E');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);

        }

        [TestMethod]
        public void MoveOneSpaceForwardTurnLeftMoveOnceSpaceForward_LoationAfterMoveIs1Minus1W()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'F', 'L', 'F' };

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(-1, 1, 'W');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MultipleMovesAndMultipleTurns_LocationAfterMoveIsMinus10N()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new[] { 'B', 'L', 'F', 'R', 'F' };

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(-1, 0, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceNorthAtTopOfGrid_LocationAfterMoveIsAtBottomOfGrid()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new char[51];
            for (int i = 0; i < 51; i++)
            {
                moveCommands[i] = 'F';
            }

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(0, -50, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceSouthABottomOfGrid_LocationAfterMoveIsAtTopOfGrid()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new char[51];
            for (int i = 0; i < 51; i++)
            {
                moveCommands[i] = 'B';
            }

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(0, 50, 'N');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceEastAtRightOfGrid_LocationAfterMoveIsAtLeftOfGrid()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new char[52];
            moveCommands[0] = 'R';
            for (int i = 1; i < 52; i++)
            {
                moveCommands[i] = 'F';
            }

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(-50, 0, 'E');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void MoveOneSpaceWestAtLeftOfGrid_LocationAfterMoveIsAtRightOfGrid()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var moveCommands = new char[52];
            moveCommands[0] = 'L';
            for (int i = 1; i < 52; i++)
            {
                moveCommands[i] = 'F';
            }

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(50, 0, 'W');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }

        [TestMethod]
        public void ObstacleInPathOfRover_RoverStopsMovingAtObstacle()
        {
            //Arrange
            var rover = new Models.PlutoRover();

            var roverController = new PlutoRoverController(rover);

            var obstacle = new ObstacleLocation(3, 0);

            var moveCommands = new[] {'R', 'F', 'F', 'F', 'F' };

            Grid.ObstacleLocations.Add(obstacle);

            //Act
            roverController.MoveRover(moveCommands);

            //Assert
            var expectedPosition = new RoverLocation(2, 0, 'E');
            Assert.AreEqual(expectedPosition.X, rover.CurrentLocation.X);
            Assert.AreEqual(expectedPosition.Y, rover.CurrentLocation.Y);
            Assert.AreEqual(expectedPosition.Direction, rover.CurrentLocation.Direction);
        }
    }
}
