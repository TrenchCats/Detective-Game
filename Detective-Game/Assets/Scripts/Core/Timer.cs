using System;

namespace MitchDroo.DetectiveGame.Core
{
    /// <summary>
    /// A countdown timer
    /// </summary>
    public class Timer : ITimer
    {
        /// <inheritdoc/>
        public float RemainingSeconds { get; set; }
        /// <inheritdoc/>
        public bool AutoReset { get; set; }
        /// <inheritdoc/>
        public bool IsEnabled { get; set; }
        /// <inheritdoc/>
        public event Action OnTimerEnd;

        private readonly float _duration;

        public Timer(float duration)
        {
            RemainingSeconds = duration;
            _duration = duration;
            IsEnabled = true;
        }

        /// <inheritdoc/>
        public void Tick(float deltaTime)
        {
            if (!IsEnabled) return;
            RemainingSeconds -= deltaTime;
            CheckForTimerEnd();
        }

        /// <summary>
        /// Checks if the timer has zero remaining seconds remaining.
        /// If so, it will invoke the OnTimerEnd event.
        /// If AutoReset is enabled, it will restart the timer
        /// </summary>
        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0f) return;
            RemainingSeconds = AutoReset ? _duration : 0f;
            OnTimerEnd?.Invoke();
        }

        /// <inheritdoc/>
        public void Start()
        {
            IsEnabled = true;
        }

        /// <inheritdoc/>
        public void Stop()
        {
            IsEnabled = false;
        }
    }
}