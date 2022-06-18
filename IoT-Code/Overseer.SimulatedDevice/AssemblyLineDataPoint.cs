using System;

namespace Overseer.SimulatedDevice
{
    /// <summary>
    /// Represents the IoT device's data point read from the assembly line.
    /// </summary>
    /// <remarks>
    /// The <see cref="JobOKSignal"/> and <see cref="JobNGSignal"/> have to be check separately in case sensor/camera having an issue.
    /// </remarks>
    public class AssemblyLineDataPoint
    {
        /// <summary>
        /// Gets the temperature value in celsius.
        /// </summary>
        /// <value>
        /// The measured temparature.
        /// </value>
        public decimal Temperature { get; init; }

        /// <summary>
        /// Gets the humidity value in grams of water vapor per kilogram of air (g.kg-1).
        /// </summary>
        /// <value>
        /// The measured humidity.
        /// </value>
        public decimal Humidity { get; init; }

        /// <summary>
        /// Gets the time span to finish assemble the product.
        /// </summary>
        /// <value>
        /// The time span to finish assemble the product.
        /// </value>
        public TimeSpan JobFinishCycle { get; init; }

        /// <summary>
        /// Gets a value indicating whether the finished product passed quality control checking.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the finished product passed quality control checking; otherwise, <c>false</c>.
        /// </value>
        public bool JobOKSignal { get; init; }

        /// <summary>
        /// Gets a value indicating whether the finished product failed quality control checking.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the finished product failed quality control checking; otherwise, <c>false</c>.
        /// </value>
        public bool JobNGSignal { get; init; }

        /// <summary>
        /// Gets a value indicating whether the quality control checking sensor has been manually turn-off.
        /// </summary>
        /// <value>
        ///   <c>true</c> if quality control checking sensor has been manually turn-off; otherwise, <c>false</c>.
        /// </value>
        public bool DeviceStatus { get; init; }

        /// <summary>
        /// Randomly generates <see cref="AssemblyLineDataPoint"/>.
        /// </summary>
        /// <returns>A randomly generated data point.</returns>
        public static AssemblyLineDataPoint GenerateRandomDataPoint()
        {
            Random rand = new();

            // random value for simulation
            var currentTemperature = DataPointConstants.MinTemperature + (decimal)rand.NextDouble() * 15;
            var currentHumidity = DataPointConstants.MinHumidity + (decimal)rand.NextDouble() * 20;
            var currentJobFinishCycle = DataPointConstants.MinJobFinishCycle.Add(new TimeSpan(0, 0, rand.Next(30) * 5));
            var currentJobOKSignal = new RandomHelper().NextBoolean();
            var currentJobNGSignal = new RandomHelper().NextBoolean();
            var currentDeviceStatus = true;

            var assemblyLineDataPoint = new AssemblyLineDataPoint
            {
                Temperature = currentTemperature,
                Humidity = currentHumidity,
                JobFinishCycle = currentJobFinishCycle,
                JobOKSignal = currentJobOKSignal,
                JobNGSignal = currentJobNGSignal,
                DeviceStatus = currentDeviceStatus,
            };

            return assemblyLineDataPoint;
        }
    }
}