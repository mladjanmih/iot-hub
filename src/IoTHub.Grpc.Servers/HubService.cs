using Grpc.Core;
using IoTHub.Grpc.Protos;
using IoTHub.Persistence.Abstractions;
using System;
using System.Threading.Tasks;


namespace IoTHub.Services
{

    public class HubService : IoTHub.Grpc.Protos.Hub.HubBase
    {
        private readonly ISensorService _sensorService;

        public HubService(ISensorService sensorService): base()
        {
            _sensorService = sensorService;
        }

        public override async Task<RegisterResponse> RegisterSensor(SensorRegisterRequest request, ServerCallContext context)
        {
            var id = await _sensorService.RegisterSensorAsync(request);
            var response = new RegisterResponse();
            if (id.HasValue)
            {
                response.Id = id.Value;
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        } 
        
        public override async Task<RegisterResponse> RegisterSensorHost(HostRegisterRequest request, ServerCallContext context)
        {
            var id = await _sensorService.RegisterSensorHostAsync(request);
            return new RegisterResponse
            {
                Id = id
            };
            
        }

        public override Task<PublishResponse> PublishSensorData(PublishSensorDataRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override Task<PublishResponse> PublishSensorDataBulk(IAsyncStreamReader<PublishSensorDataRequest> requestStream, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}
