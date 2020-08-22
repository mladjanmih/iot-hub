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

        public int? RegisterSensor(SensorRegisterRequest request)
        {
            var host = _context.SensorHosts.FirstOrDefault(x => x.Id == request.HostId);
            if (host == null)
            {
                return null;
            }

            var sensor = _context.Sensors.FirstOrDefault(x => x.HostSensorId == request.HostSensorId);
            if (sensor != null)
            {
                return sensor.Id;
            }

            sensor = _mapper.Map<Sensor>(request);
            sensor.Host = host;
            _context.Sensors.Add(sensor);
            _context.SaveChanges();
            return sensor.Id;
        }

        public int RegisterSensorHost(HostRegisterRequest request, string mac)
        {
            var host = _context.SensorHosts.FirstOrDefault(x => x.Mac == mac);
            if (host != null)
            {
                return host.Id;
            }

            host = _mapper.Map<SensorHost>(request);
            host.Mac = mac;
            _context.SensorHosts.Add(host);
            _context.SaveChanges();
            return host.Id;
        }    
    }
}
