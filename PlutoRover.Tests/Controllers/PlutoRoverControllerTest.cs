﻿using System;
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




    }
}
