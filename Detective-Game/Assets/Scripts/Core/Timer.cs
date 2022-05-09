using System;

namespace MitchDroo.DetectiveGame.Core
{
    public class Timer
    {
        public float RemainingSeconds { get; set; }
        public bool IsEnabled { get; set; }

        public event Action OnTimerEnd;

        public Timer(float duration)
        {
            RemainingSeconds = duration;
        }

        public void Tick(float deltaTime)
        {
            if (!IsEnabled) return;

            RemainingSeconds -= deltaTime;
            if (RemainingSeconds <= 0f)
            {
                RemainingSeconds = 0f;
                OnTimerEnd?.Invoke();
            }
        }
    }
}