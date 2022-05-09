using MitchDroo.DetectiveGame.Combat;
using NUnit.Framework;

namespace MitchDroo.DetectiveGame.Tests.Combat
{
    [TestFixture]
    public class HealthTests
    {
        [Test]
        public void SetStartingAndMaxHealth_GivenJustMaxHealth()
        {
            Health health = new Health(10);
            Assert.AreEqual(10, health.CurrentHealth);
            Assert.AreEqual(10, health.MaxHealth);
        }

        [Test]
        public void SetStartingAndMaxHealth_GivenStartingAndMaxHealth()
        {
            Health health = new Health(10, 10);
            Assert.AreEqual(10, health.CurrentHealth);
            Assert.AreEqual(10, health.MaxHealth);
        }

        [Test]
        public void TakeDamage_AboveZeroHealth_ReturnsDecrementedHealth()
        {
            Health health = new Health(5);

            health.TakeDamage(1);
            
            Assert.AreEqual(5 - 1, health.CurrentHealth);
            Assert.AreEqual(5, health.MaxHealth);
        }

        [Test]
        public void TakeDamage_BelowZeroHealth_ReturnsZero()
        {
            Health health = new Health(1);
            health.TakeDamage(10);
            Assert.AreEqual(0, health.CurrentHealth);
            Assert.AreEqual(1, health.MaxHealth);
        }

        [Test]
        public void ReceiveHealth_BelowMaxHealth_ReturnsIncrementedHealth()
        {
            Health health = new Health(1, 10);
            health.ReceiveHealth(1);
            Assert.AreEqual(1 + 1, health.CurrentHealth);
            Assert.AreEqual(10, health.MaxHealth);
        }

        [Test]
        public void ReceiveHealth_AboveMaxHealth_ReturnsMaxHealth()
        {
            Health health = new Health(1, 10);
            health.ReceiveHealth(20);
            Assert.AreEqual(10, health.CurrentHealth);
            Assert.AreEqual(10, health.MaxHealth);
        }

        [Test]
        public void IsDead_ZeroHealth_ReturnsTrue()
        {
            Health health = new Health(1);
            health.TakeDamage(1);
            Assert.IsTrue(health.IsDead);
        }

        [Test]
        public void IsDead_MoreThanZeroHealth_ReturnsFalse()
        {
            Health health = new Health(10);
            health.TakeDamage(1);
            Assert.IsFalse(health.IsDead);
        }
    }
}
