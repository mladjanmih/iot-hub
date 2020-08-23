using AutoMapper;
using IoTHub.Grpc.Protos;
using IoTHub.Persistence.Abstractions;
using IoTHub.Persistence.MapperProfiles;
using IoTHub.Persistence.Models;
using IoTHub.Persistence.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensor = IoTHub.Persistence.Models.Sensor;

namespace IoTHub.Persistence.Services
{
    public class SqliteSensorService : ISensorService
    {
        private readonly SensorContext _context;
        private readonly IMapper _mapper;
        public SqliteSensorService(SensorContext sensorContext)
        {
            _context = sensorContext;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new SensorProfile())).CreateMapper();
        }

        public Task<int?> RegisterSensorAsync(SensorRegisterRequest request)
        {
            var host = _context.SensorHost.FirstOrDefault(x => x.Id == request.HostId);
            if (host == null)
            {
                return null;
            }

            var sensor = _context.Sensor.FirstOrDefault(x => x.HostSensorId == request.HostSensorId);
            if (sensor != null)
            {
                return Task.FromResult<int?>(sensor.Id);
            }

            sensor = _mapper.Map<Sensor>(request);
            sensor.Host = host;
            _context.Sensor.Add(sensor);
            _context.SaveChanges();
            return Task.FromResult<int?>(sensor.Id);
        }

        public Task<int> RegisterSensorHostAsync(HostRegisterRequest request)
        {
            var host = _context.SensorHost.FirstOrDefault(x => x.NetworkId == request.NetworkId);
            if (host != null)
            {
                return Task.FromResult(host.Id);
            }

            host = _mapper.Map<SensorHost>(request);
            _context.SensorHost.Add(host);
            _context.SaveChanges();
            return Task.FromResult(host.Id);
        }    
    }
}
