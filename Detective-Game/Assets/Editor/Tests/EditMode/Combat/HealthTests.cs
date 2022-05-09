using MitchDroo.DetectiveGame.Combat;
using NUnit.Framework;

namespace MitchDroo.DetectiveGame.Tests.Combat
{
    [TestFixture]
    public class HealthTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(30)]
        public void SetStartingAndMaxHealth_GivenJustMaxHealth(int maxHealth)
        {
            Health health = new Health(maxHealth);
            Assert.AreEqual(maxHealth, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
            Assert.IsTrue(health.CurrentHealth <= health.MaxHealth);
            Assert.IsTrue(health.CurrentHealth != 0);
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(5, 10)]
        [TestCase(10, 20)]
        [TestCase(30, 30)]
        public void SetStartingAndMaxHealth_GivenStartingAndMaxHealth(int currentHealth, int maxHealth)
        {
            Health health = new Health(currentHealth, maxHealth);
            Assert.AreEqual(currentHealth, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
            Assert.IsTrue(health.CurrentHealth <= health.MaxHealth);
            Assert.IsTrue(health.CurrentHealth != 0);
        }

        [Test]
        [TestCase(5, 1)]
        [TestCase(10, 5)]
        [TestCase(20, 10)]
        public void TakeDamage_AboveZeroHealth_ReturnsDecrementedHealth(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);

            health.TakeDamage(damage);
            
            Assert.AreEqual(maxHealth - damage, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(5, 10)]
        [TestCase(10, 20)]
        public void TakeDamage_BelowZeroHealth_ReturnsZero(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            health.TakeDamage(damage);
            Assert.AreEqual(0, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(5, 10)]
        [TestCase(10, 20)]
        public void TakeDamage_OnHealthChangedIsInvoked(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            bool isInvoked = false;

            health.OnHealthChanged += (v) => isInvoked = true;

            health.TakeDamage(damage);

            Assert.IsTrue(isInvoked);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(5, 10)]
        [TestCase(10, 20)]
        public void TakeDamage_BelowZeroHealth_OnHealthDepletedIsInvoked(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            bool isInvoked = false;
            health.OnHealthDepleted += () => isInvoked = true;

            health.TakeDamage(damage);
            
            Assert.IsTrue(isInvoked);
        }

        [Test]
        [TestCase(5, 1)]
        [TestCase(10, 5)]
        [TestCase(20, 10)]
        public void TakeDamage_AboveZeroHealth_OnHealthDepletedIsNotInvoked(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            bool isInvoked = false;
            health.OnHealthDepleted += () => isInvoked = true;

            health.TakeDamage(damage);

            Assert.IsFalse(isInvoked);
        }

        [Test]
        [TestCase(1, 10, 1)]
        [TestCase(5, 20, 10)]
        [TestCase(10, 50, 20)]
        public void ReceiveHealth_BelowMaxHealth_ReturnsIncrementedHealth(int currentHealth, int maxHealth, int amount)
        {
            Health health = new Health(currentHealth, maxHealth);
            health.ReceiveHealth(amount);
            Assert.AreEqual(currentHealth + amount, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
        }

        [Test]
        [TestCase(1, 10, 20)]
        [TestCase(5, 20, 50)]
        [TestCase(10, 50, 100)]
        public void ReceiveHealth_AboveMaxHealth_ReturnsMaxHealth(int currentHealth, int maxHealth, int amount)
        {
            Health health = new Health(currentHealth, maxHealth);
            health.ReceiveHealth(amount);
            Assert.AreEqual(maxHealth, health.CurrentHealth);
            Assert.AreEqual(maxHealth, health.MaxHealth);
        }

        [Test]
        [TestCase(1, 10, 1)]
        [TestCase(5, 20, 10)]
        [TestCase(10, 50, 20)]
        public void ReceiveHealth_OnHealthChangedIsInvoked(int currentHealth, int maxHealth, int amount)
        {
            Health health = new Health(currentHealth, maxHealth);
            bool isInvoked = false;

            health.OnHealthChanged += (v) => isInvoked = true;

            health.ReceiveHealth(amount);

            Assert.IsTrue(isInvoked);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(5, 10)]
        [TestCase(10, 20)]
        public void IsDead_ZeroHealth_ReturnsTrue(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            health.TakeDamage(damage);
            Assert.IsTrue(health.IsDead);
        }

        [Test]
        [TestCase(5, 1)]
        [TestCase(10, 5)]
        [TestCase(20, 10)]
        public void IsDead_MoreThanZeroHealth_ReturnsFalse(int maxHealth, int damage)
        {
            Health health = new Health(maxHealth);
            health.TakeDamage(damage);
            Assert.IsFalse(health.IsDead);
        }
    }
}
