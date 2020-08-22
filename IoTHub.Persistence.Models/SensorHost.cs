using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IoTHub.Persistence.Models
{
    public class SensorHost
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public string Mac { get; set; }

        public string Name { get; set; }

        public virtual List<Sensor> Sensors { get; set; }
    }
}
