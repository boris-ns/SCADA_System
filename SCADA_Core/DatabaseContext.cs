using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCADA_Core
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Alarm> Alarms { get; set; }

        public DatabaseContext()
            : base("scada_core")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}