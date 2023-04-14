using Microsoft.EntityFrameworkCore;
using Prioritify.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.DbContexts {
    public class UserDbContext : DbContext {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {

        }

        public DbSet<TbUsers> TbUsers { get; set; }
        public DbSet<TbAccounts> TbAccounts { get; set; }
        public DbSet<TbUserRoles> TbUserRoles { get; set; }
        public DbSet<TbRoles> TbRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TbUsers>()
                .ToTable("tbusers", schema: "users");
            modelBuilder.Entity<TbAccounts>()
                .ToTable("tbaccounts", schema: "users");
            modelBuilder.Entity<TbUserRoles>()
                .ToTable("tbuserroles", schema: "users");
            modelBuilder.Entity<TbRoles>()
                .ToTable("tbroles", schema: "users");

            modelBuilder.Entity<TbUsersOperations>()
                .ToTable("tbusersops", schema: "users");
            modelBuilder.Entity<TbAccountsOperations>()
                .ToTable("tbaccountsops", schema: "users");
        }
    }
}
