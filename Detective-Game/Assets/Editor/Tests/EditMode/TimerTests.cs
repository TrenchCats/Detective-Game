using NUnit.Framework;
using MitchDroo.DetectiveGame.Core;

namespace MitchDroo.DetectiveGame.Tests.Core
{
    [TestFixture]
    public class TimerTests
    {
        [Test]
        [TestCase(1f)]
        [TestCase(5f)]
        [TestCase(36.3f)]
        public void SetStartingDuration_GivenDuration(float duration)
        {
            Timer timer = new Timer(duration);
            Assert.AreEqual(timer.RemainingSeconds, duration);
        }

        [Test]
        [TestCase(1f, 0.5f)]
        [TestCase(5f, 3f)]
        [TestCase(36.3f, 0.5f)]
        public void Tick_AboveZeroSeconds_RemainingSecondsIsReduced(float duration, float deltaTime)
        {
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;
            timer.Tick(deltaTime);
            Assert.AreEqual(duration - deltaTime, timer.RemainingSeconds);
        }

        [Test]
        [TestCase(1f, 0.5f)]
        [TestCase(5f, 3f)]
        [TestCase(36.3f, 0.5f)]
        public void Tick_AboveZeroSeconds_OnTimerEndIsNotInvoked(float duration, float deltaTime)
        {
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;
            bool isInvoked = false;
            timer.OnTimerEnd += () => isInvoked = true;

            timer.Tick(deltaTime);

            Assert.IsFalse(isInvoked);
        }

        [Test]
        [TestCase(0f, 2f)]
        [TestCase(10f, 20f)]
        public void Tick_BelowZeroSeconds_StopsAtZeroSeconds(float duration, float deltaTime)
        {
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;

            timer.Tick(deltaTime);

            Assert.AreEqual(0f, timer.RemainingSeconds);
        }

        [Test]
        [TestCase(0f, 2f)]
        [TestCase(10f, 20f)]
        public void Tick_BelowZeroSeconds_OnTimerEndIsInvoked(float duration, float deltaTime)
        {
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;

            bool isInvoked = false;
            timer.OnTimerEnd += () => isInvoked = true;

            timer.Tick(deltaTime);

            Assert.IsTrue(isInvoked);
        }

        [Test]
        [TestCase(0f, 2f)]
        [TestCase(1f, 0.5f)]
        [TestCase(5f, 3f)]
        [TestCase(10f, 20f)]
        [TestCase(36.3f, 0.5f)]
        public void Tick_DoesNotDecrement_WhenDisabled(float duration, float deltaTime)
        {
            Timer timer = new Timer(duration);
            timer.IsEnabled = false;

            bool isInvoked = false;
            timer.OnTimerEnd += () => isInvoked = true;

            timer.Tick(deltaTime);

            Assert.AreEqual(duration, timer.RemainingSeconds);
            Assert.IsFalse(isInvoked);
        }
    }
}
