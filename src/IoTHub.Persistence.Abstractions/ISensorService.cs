using IoTHub.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoTHub.Persistence.Abstractions
{
    public interface ISensorService
    {
        Task<int?> RegisterSensorAsync(SensorRegisterRequest request);

        Task<int> RegisterSensorHostAsync(HostRegisterRequest request);

        Task<bool> SaveMeasurementData(PublishSensorDataRequest request);
    }
}
