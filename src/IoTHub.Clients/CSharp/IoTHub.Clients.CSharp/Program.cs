using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace IoTHub.Clients.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Grpc.Protos.Hub.HubClient(channel);
            var response = client.RegisterSensorHost(new Grpc.Protos.HostRegisterRequest()
            {
                Name = "CSharp Host",
                NetworkId = "c2968e19-afb6-41d2-9d6f-f68eee686d87"
            });

            var sensorResponse = client.RegisterSensor(new Grpc.Protos.SensorRegisterRequest()
            {
                Name = "CPU",
                HostId = response.Id,
                HostSensorId = 2,
                UnitName = "CPU Time(s)"
            });
            // YOUR CODE GOES HERE

            System.Console.WriteLine($"Host ID: {response.Id} Sensor ID: {sensorResponse.Id} ");

            channel.ShutdownAsync().Wait();
        }
    }
}
