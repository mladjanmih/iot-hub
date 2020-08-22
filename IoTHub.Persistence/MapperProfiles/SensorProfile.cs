using AutoMapper;
using IoTHub.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Persistence.MapperProfiles
{
    public class SensorProfile: Profile
    {
        public SensorProfile()
        {
            CreateMap<Grpc.Protos.SensorRegisterRequest, Sensor>().ForMember(x => x.Id, a => a.Ignore());
            CreateMap<Grpc.Protos.HostRegisterRequest, SensorHost>().ForMember(x => x.Id, a => a.Ignore());
        }
    }
}
