using System;

namespace MitchDroo.DetectiveGame.Core
{
    /// <summary>
    /// Interface for a countdown timer
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// The number of seconds remaining for the timer
        /// </summary>
        float RemainingSeconds { get; set; }

        /// <summary>
        /// Whether the timer is automatically reset when it reaches zero remaining seconds
        /// </summary>
        bool AutoReset { get; set; }

        /// <summary>
        /// Whether the timer is enabled or disabled
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Invokes every time the timer reaches zero remaining seconds
        /// </summary>
        event Action OnTimerEnd;

        /// <summary>
        /// Starts the timer
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the timer
        /// </summary>
        void Stop();

        /// <summary>
        /// Ticks down the remaining seconds of the timer
        /// </summary>
        /// <param name="deltaTime"></param>
        void Tick(float deltaTime);
    }
}