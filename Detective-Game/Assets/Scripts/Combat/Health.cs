using System;

namespace MitchDroo.DetectiveGame.Combat
{
    public class Health
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead => CurrentHealth <= 0;

        public event Action<int> OnHealthChanged;
        public event Action OnHealthDepleted;

        public Health(int maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
        }

        public Health(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            if (CurrentHealth <= 0)
            {
                OnHealthDepleted?.Invoke();
            }
            OnHealthChanged?.Invoke(CurrentHealth);
        }

        public void ReceiveHealth(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}