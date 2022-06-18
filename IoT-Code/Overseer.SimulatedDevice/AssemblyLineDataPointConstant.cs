using System;

namespace Overseer.SimulatedDevice
{
    /// <summary>
    /// The collection of constant value for randomly generate data point and alert threshold.
    /// </summary>
    public static class DataPointConstants
    {
        /// <summary>
        /// The minimum temperature;
        /// Default value is 30 celsius.
        /// </summary>
        public const decimal MinTemperature = 30;

        /// <summary>
        /// The temperature alert threshold;
        /// Default value is 50 celsius.
        /// </summary>
        public const decimal TemperatureAlertThreshold = 60;

        /// <summary>
        /// The minimum humidity;
        /// Default value is 90.
        /// </summary>
        public const decimal MinHumidity = 50;

        /// <summary>
        /// The minimum time to finish assemble one product (aka. complete one job);
        /// Default value is 90 seconds.
        /// </summary>
        public static TimeSpan MinJobFinishCycle = new(0, 0, 90);

        /// <summary>
        /// The time to finish assemble one product threshold;
        /// Default value is 120 seconds.
        /// </summary>
        public static TimeSpan JobFinishCycleAlertThreshold = new(0, 0, 120);
    }
}