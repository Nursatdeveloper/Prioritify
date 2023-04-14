using Microsoft.EntityFrameworkCore;
using Prioritify.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.DbContexts {
    public class PrioritifyDbContext : DbContext {
        public PrioritifyDbContext(DbContextOptions<PrioritifyDbContext> options) : base(options){

        }
        public DbSet<TbTasks> TbTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TbTasks>()
                .ToTable("tbtasks", schema: "application");
        }
    }
}
