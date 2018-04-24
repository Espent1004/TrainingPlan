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
using Model.Database;

namespace DAL
{
    public class TpContext : DbContext
    {
        public TpContext() : base("name=TrainingPlanDatabase")
        {
            Database.SetInitializer(new DbInit());

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Comment> Comment { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
