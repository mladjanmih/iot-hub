using Grpc.Core;
using IoTHub.Grpc.Protos;
using System.Threading.Tasks;

namespace IoTHub.Services
{
    public class HubService : IoTHub.Grpc.Protos.Hub.HubBase
    {
        public override Task<RegisterResponse> RegisterSensor(SensorRegisterRequest request, ServerCallContext context)
        {
            return base.RegisterSensor(request, context);
        } 
        
        public override Task<RegisterResponse> RegisterSensorHost(HostRegisterRequest request, ServerCallContext context)
        {
            return base.RegisterSensorHost(request, context);
        }
    }
}
