using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;
using System.Text.Json.Serialization;

namespace IoTHub.Persistence.Models
{
    public enum DataType
    {
        Integer,
        Double
    }

    public class Measurement
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public dynamic Data { get; set; }

        public DataType DataType { get; set; }

        public DateTime MeasurementTime { get; set; }

        [JsonIgnore]
        public Sensor Sensor { get; set; }

        public int SensorId { get; set; }

    }
}
