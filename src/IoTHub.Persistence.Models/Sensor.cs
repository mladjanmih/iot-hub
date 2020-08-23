using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace IoTHub.Persistence.Models
{
    public class Sensor
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public int HostSensorId { get; set; }

        public string Name { get; set; }

        public string UnitName { get; set; }

        [JsonIgnore]
        public SensorHost Host { get; set; }

        public int HostId { get; set; }
    }
}
