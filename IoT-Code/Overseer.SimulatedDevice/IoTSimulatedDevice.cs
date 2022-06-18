using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.SimulatedDevice
{
    /// <summary>
    /// The console application for simulate IoT device telemetry and send to Azure IoT Hub.
    /// </summary>
    /// <remarks>
    /// To build this application, it require .NET 6 SDK, C# 11, and Azure IoT Hub device SDK for .NET installed.
    /// </remarks>
    internal class IoTSimulatedDevice
    {
        /// <summary>
        /// The device connection string to authenticate the device with Azure IoT Hub.
        /// </summary>
        private const string AzureIoTConnectionString = "";

        /// <summary>
        /// The delay time between message in milliseconds.
        /// </summary>
        private const int DelayMilliseconds = 1000;

        /// <summary>
        /// The Azure device client.
        /// </summary>
        private static DeviceClient deviceClient;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Simulating IoT device telemetry. Press Ctrl-C to exit.\n");

            try
            {
                // connect device to the IoT hub using the MQTT protocol
                deviceClient = DeviceClient.CreateFromConnectionString(AzureIoTConnectionString, TransportType.Mqtt);

                // loop sending telemetry
                SendTelemetryToAzureIoTHubAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to connect to Azure IoT Hub. \n{ex}");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Sends the randomly generated telemetry to Azure IoT Hub.
        /// </summary>
        private static async void SendTelemetryToAzureIoTHubAsync()
        {
            while (true)
            {
                // intialize data point and message
                var generatedDataPoint = AssemblyLineDataPoint.GenerateRandomDataPoint();
                var message = CreateAzureIoTMessage(generatedDataPoint);

                // send the telemetry message
                await deviceClient.SendEventAsync(message).ConfigureAwait(false);
                Console.WriteLine("{0} >> Sending message: {1}", DateTime.Now, JsonConvert.SerializeObject(generatedDataPoint));

                await Task.Delay(DelayMilliseconds).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Creates the Azure IoT message from <see cref="AssemblyLineDataPoint"/>.
        /// </summary>
        /// <param name="assemblyLineDataPoint">The assembly line data point.</param>
        /// <returns>Azure IoT device client message.</returns>
        private static Message CreateAzureIoTMessage(AssemblyLineDataPoint assemblyLineDataPoint)
        {
            var messageString = JsonConvert.SerializeObject(assemblyLineDataPoint);
            var message = new Message(Encoding.ASCII.GetBytes(messageString));

            // A custom property to the message.
            // IoT hub can filter on these properties without access to the message body.
            message.Properties.Add("temperatureAlert", (assemblyLineDataPoint.Temperature > DataPointConstants.TemperatureAlertThreshold) ? "true" : "false");
            message.Properties.Add("jobFinishCycleAlert", (assemblyLineDataPoint.JobFinishCycle > DataPointConstants.JobFinishCycleAlertThreshold) ? "true" : "false");
            message.Properties.Add("cameraFailureAlert", ((!assemblyLineDataPoint.JobOKSignal && !assemblyLineDataPoint.JobNGSignal) || (assemblyLineDataPoint.JobOKSignal && assemblyLineDataPoint.JobNGSignal)) ? "true" : "false");
            message.Properties.Add("sensorTurnOffAlert", (!assemblyLineDataPoint.DeviceStatus) ? "true" : "false");

            return message;
        }
    }
}