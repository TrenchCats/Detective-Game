using System;

namespace MitchDroo.DetectiveGame.Combat
{
    /// <summary>
    /// The Health Component of an Entity
    /// </summary>
    public class Health
    {
        private int _currentHealth;
        private int _maxHealth;

        /// <summary>
        /// The current health value of the entity
        /// </summary>
        public int CurrentHealth
        {
            get => _currentHealth; 
            set => _currentHealth = value;
        }

        /// <summary>
        /// The maximum health value of the entity
        /// </summary>
        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        /// <summary>
        /// Returns true if <c>CurrentHealth</c> is less than or equal to zero
        /// </summary>
        public bool IsDead => CurrentHealth <= 0;

        /// <summary>
        /// Is invoked every time <c>CurrentHealth</c> is changed
        /// </summary>
        public event Action<int> OnHealthChanged;

        /// <summary>
        /// Is invoked when <c>CurrentHealth</c> is less than or equal to zero
        /// </summary>
        public event Action OnHealthDepleted;

        public Health(int maxHealth)
        {
            _currentHealth = maxHealth;
            _maxHealth = maxHealth;
        }

        public Health(int currentHealth, int maxHealth)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
        }

        /// <summary>
        /// Decreases the current health of the entity. Cannot exceed zero.
        /// </summary>
        /// <param name="amount"></param>
        public void TakeDamage(int amount)
        {
            _currentHealth = Math.Max(_currentHealth - amount, 0);
            if (_currentHealth <= 0) OnHealthDepleted?.Invoke();
            OnHealthChanged?.Invoke(_currentHealth);
        }

        /// <summary>
        /// Increases the current health of the entity. Cannot exceed the maximum health value.
        /// </summary>
        /// <param name="amount"></param>
        public void ReceiveHealth(int amount)
        {
            _currentHealth = Math.Min(_currentHealth + amount, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }
}