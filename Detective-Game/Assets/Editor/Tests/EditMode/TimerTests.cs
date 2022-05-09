using NUnit.Framework;

namespace MitchDroo.DetectiveGame.Tests.Core
{
    [TestFixture]
    public class TimerTests
    {
        [Test]
        public void SetStartingDuration_GivenDuration()
        {
            float duration = 1f;
            Timer timer = new Timer(duration);
            Assert.AreEqual(timer.RemainingSeconds, duration);
        }

        [Test]
        public void Tick_AboveZeroSeconds_RemainingSecondsIsReduced()
        {
            var duration = 1f;
            var deltaTime = 1f;
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;
            timer.Tick(duration);
            Assert.AreEqual(duration - deltaTime, timer.RemainingSeconds);
        }

        [Test]
        public void Tick_AboveZeroSeconds_OnTimerEndIsNotInvoked()
        {
            var duration = 1f;
            var deltaTime = 0.5f;
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;
            bool isInvoked = false;
            timer.OnTimerEnd += () => isInvoked = true;

            timer.Tick(deltaTime);

            Assert.IsFalse(isInvoked);
        }

        [Test]
        public void Tick_BelowZeroSeconds_StopsAtZeroSeconds()
        {
            var duration = 0f;
            var deltaTime = 2f;
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;

            timer.Tick(deltaTime);

            Assert.AreEqual(0f, timer.RemainingSeconds);
        }

        [Test]
        public void Tick_BelowZeroSeconds_OnTimerEndIsInvoked()
        {
            var duration = 0f;
            var deltaTime = 1f;
            Timer timer = new Timer(duration);
            timer.IsEnabled = true;
            bool isInvoked = false;
            timer.OnTimerEnd += () => isInvoked = true;

            timer.Tick(deltaTime);

            Assert.IsTrue(isInvoked);
        }

        [Test]
        public void Tick_DoesNotDecrement_WhenDisabled()
        {
            var duration = 1f;
            var deltaTime = 1f;
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
