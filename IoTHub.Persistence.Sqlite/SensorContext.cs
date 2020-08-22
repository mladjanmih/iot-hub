using IoTHub.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Persistence.Sqlite
{
    public class SensorContext: DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<SensorHost> SensorHosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source=iothub.db");
        }
    }
}
