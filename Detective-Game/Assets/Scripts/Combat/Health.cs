namespace MitchDroo.DetectiveGame.Combat
{
    public class Health
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead => CurrentHealth <= 0;

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
        }

        public void ReceiveHealth(int amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
    }
}