using Microsoft.EntityFrameworkCore;
using Prioritify.Data.Tables;

namespace Prioritify.Data.DbContexts {
    public class SystemDbContext : DbContext {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) {

        }
        public DbSet<TbExceptions> TbExceptions { get; set; }
        public DbSet<TbLogs> TbLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TbExceptions>()
                .ToTable("tbexceptions", schema: "system");

            modelBuilder.Entity<TbLogs>()
                .ToTable("tblogs", schema: "system");
        }

    }

}
