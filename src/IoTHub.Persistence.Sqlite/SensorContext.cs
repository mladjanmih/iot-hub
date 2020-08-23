using IoTHub.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTHub.Persistence.Sqlite
{
    public class SensorContext: DbContext
    {
        public SensorContext(): base()
        {
            Database.EnsureCreated();
        }

        public SensorContext(DbContextOptions options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Sensor> Sensor { get; set; }

        public DbSet<SensorHost> SensorHost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source=iothub.db");
        }
    }
}
