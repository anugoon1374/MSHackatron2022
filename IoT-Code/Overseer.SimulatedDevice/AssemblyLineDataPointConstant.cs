using System;

namespace Overseer.SimulatedDevice
{
    /// <summary>
    /// The collection of constant value for randomly generate data point.
    /// </summary>
    public static class DataPointConstants
    {
        /// <summary>
        /// The minimum temperature;
        /// Default value is 20 celsius.
        /// </summary>
        public const decimal minTemperature = 20;

        /// <summary>
        /// The minimum humidity;
        /// Default value is 90.
        /// </summary>
        public const decimal minHumidity = 60;

        /// <summary>
        /// The minimum time to finish assemble one product (aka. complete one job);
        /// Default value is 90 seconds.
        /// </summary>
        public static TimeSpan minJobFinishCycle = new(0, 0, 90);
    }
}