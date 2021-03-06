﻿using LawnMower;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LawnMowerTests
{
    [TestClass]
    public class MowerTests
    {
        public MowerTests()
        {
            _lawn = new Lawn(10, 10);
        }

        private readonly Lawn _lawn;

        [TestMethod]
        public void Ensure_Current_Position_Returns_String_In_Correct_Format()
        {
            var mower = new Mower(1, 1, "n", _lawn);
            Assert.AreEqual(mower.ToString(), "1 1 N");
        }

        [TestMethod]
        public void Ensure_Mower_Heads_West_From_North_On_Left_Command_Without_Changing_Position()
        {
            var mower = new Mower(1, 1, "n", _lawn);
            mower.Mowe("l");
            Assert.AreEqual(mower.ToString(), "1 1 W");
        }

        [TestMethod]
        public void Ensure_Mower_Heads_North_From_West_On_Right_Command_Without_Changing_Position()
        {
            var mower = new Mower(1, 1, "w", _lawn);
            mower.Mowe("r");
            Assert.AreEqual(mower.ToString(), "1 1 N");
        }

        [TestMethod]
        public void Ensure_Mower_Does_Not_Move_Beyond_The_Lawn()
        {
            var mower = new Mower(1, 1, "w", _lawn);
            mower.Mowe("RMMMMMMMMMMMMRMMMMMMMMMMMMRMMMMMMMMMMMMRMMMMMMMMMMMM");
            Assert.AreEqual(mower.ToString(), "1 1 W");
        }

        [TestMethod]
        public void Ensure_Invalid_Mower_Postion_Sets_Coordinate_To_One()
        {
            var mower = new Mower(0, 0, "w", _lawn);
            Assert.AreEqual(mower.ToString(), "1 1 W");
        }
    }
}