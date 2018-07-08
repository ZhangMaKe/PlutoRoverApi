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

            var expectedPosition = new Tuple<int, int, char>(0, 1, 'N');
            Assert.AreEqual(expectedPosition, rover.CurrentLocation);
        }
    }
}
