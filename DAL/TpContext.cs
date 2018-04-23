using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DAL
{
    public class TpContext : DbContext
    {
        public TpContext() : base("name=TrainingPlanDatabase")
        {
            Database.SetInitializer(new DbInit());

        }

        //public DbSet<AirplaneModels> AirplaneModels { get; set; }
        //public DbSet<Airplanes> Airplanes { get; set; }
        //public DbSet<Airports> Airports { get; set; }
        //public DbSet<Flights> Flights { get; set; }
        //public DbSet<Orders> Orders { get; set; }
        //public DbSet<Contacts> Contacts { get; set; }
        //public DbSet<Tickets> Tickets { get; set; }
        //public DbSet<Travellers> Travellers { get; set; }
        //public DbSet<Cards> Cards { get; set; }
        //public DbSet<Payments> Payments { get; set; }
        //public DbSet<DBStatus> Status { get; set; }
        //public DbSet<ChangeLogs> ChangeLogs { get; set; }
        //public DbSet<Users> Users { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
