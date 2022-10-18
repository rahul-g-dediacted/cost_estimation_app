using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreClient.Models;

namespace NetCoreClient
{
    namespace ConsoleApp.PostgreSQL
    {
        public class BloggingContext : DbContext
        {

            public DbSet<LocationEntity> LocationEntity { get; set; }
            public DbSet<ReleaseEntity> ReleaseEntity { get; set; }
            public DbSet<AssemblyCatelogEntity> AssemblyCatelogEntity { get; set; }
            public DbSet<AssemblyCostLineEntity> AssemblyCostLineEntity { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseNpgsql("Host=localhost;Database=RSmean;Username=postgres;Password=Hoang218@");
        }

    }
}
