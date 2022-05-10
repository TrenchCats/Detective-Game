using System;

namespace MitchDroo.DetectiveGame.Core
{
    public class Timer
    {
        private float _duration;

        public float RemainingSeconds { get; set; }
        public bool IsEnabled { get; set; }
        public bool AutoReset { get; set; }

        public event Action OnTimerEnd;

        public Timer(float duration)
        {
            _duration = duration;
            RemainingSeconds = duration;
        }

        public void Tick(float deltaTime)
        {
            if (!IsEnabled) return;

            RemainingSeconds -= deltaTime;
            if (RemainingSeconds <= 0f)
            {
                if (AutoReset)
                {
                    RemainingSeconds = _duration;
                }
                else
                {
                    RemainingSeconds = 0f;
                }
                OnTimerEnd?.Invoke();
            }
        }

        public void Start()
        {
            IsEnabled = true;
        }

        public void Stop()
        {
            IsEnabled = false;
        }
    }
}