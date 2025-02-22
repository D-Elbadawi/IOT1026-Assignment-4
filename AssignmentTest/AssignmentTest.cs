﻿using Assignment;
using Assignment.InterfaceCommand; // Update to Assignment.InterfaceCommand file

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void PropertiesTest()
        {
            Robot robot1 = new Robot();
            Assert.AreEqual(robot1.NumCommands, 6);
            const int ExpectedCommands = 10;
            Robot robot2 = new Robot(ExpectedCommands);
            Assert.AreEqual(robot2.NumCommands, ExpectedCommands);

            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);

            Assert.AreEqual(robot1.X, 0);
            // Moves the robot can move even though it is off!!
            // This is very bad! Not good encapsulation
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);

            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }
    }
}
