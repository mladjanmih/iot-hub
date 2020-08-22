using IoTHub.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Persistence.Abstractions
{
    public interface ISensorService
    {
        int? RegisterSensor(SensorRegisterRequest request);

        int RegisterSensorHost(HostRegisterRequest request, string mac);
    }
}
