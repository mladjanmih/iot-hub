using IoTHub.Grpc.Protos;
using IoTHub.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Persistence.Services
{
    public class MongoSensorService : ISensorService
    {
        public int RegisterSensor(SensorRegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public int RegisterSensorHost(HostRegisterRequest , string mac)
        {
            throw new NotImplementedException();
        }
    }
}
