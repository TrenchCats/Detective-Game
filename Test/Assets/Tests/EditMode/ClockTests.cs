using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ClockTests
    {
        [Test]
        public void Clock_Should_Have_Initial_Time()
        {
            Clock clock = new Clock(10, 10);
            Assert.AreEqual(clock.Hour, 10);
            Assert.AreEqual(clock.Minute, 10);
        }

        [Test]
        public void Clock_Should_Increase_Time()
        {
            Clock a = new Clock(10, 0);
            Clock b = new Clock(1, 30);

            Clock clock = a + b;
            Assert.AreEqual(clock.Hour, 11);
            Assert.AreEqual(clock.Minute, 30);
        }

        [Test]
        public void Clock_Should_Have_Equal_Time()
        {
            Clock a = new Clock(10, 30);
            Clock b = new Clock(10, 30);

            Assert.IsTrue(a == b);
        }

        [Test]
        [TestCase(0, 30)]
        [TestCase(10, 10)]
        public void Clock_Should_Return_Current_Time(int hour, int minute)
        {
            Clock clock = new Clock(hour, minute);
            string currentTime = clock.TimeString;
            Assert.AreEqual(currentTime, $"{ hour }:{minute}");
        }
    }
}
