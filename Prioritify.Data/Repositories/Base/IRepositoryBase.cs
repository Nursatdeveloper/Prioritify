using Microsoft.EntityFrameworkCore;
using Prioritify.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Repositories.Base {
    public interface IRepositoryBase<TContext, TModel> 
        where TContext : DbContext
        where TModel : DbModelBase {

        Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter);
        Task<TModel> InsertAsync(TModel entity);
        Task UpdateAsync(TModel entity);
        Task DeleteAsync(TModel entity);
    }

    public class RepositoryBase<TContext, TModel>: IRepositoryBase<TContext, TModel>
        where TContext : DbContext
        where TModel : DbModelBase {

        private TContext _context;
        public RepositoryBase(TContext context) {
            _context = context;
        }
        public Task DeleteAsync(TModel entity) {
            throw new NotImplementedException();
        }

        public Task<TModel> GetAsync(Expression<Func<TModel, bool>> filter) {
            throw new NotImplementedException();
        }

        public async Task<TModel> InsertAsync(TModel entity) {
            try {
                var createdObject = await _context.Set<TModel>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return createdObject.Entity;
            } catch(Exception ex) {
                //await _tbExceptions.InsertAsync(new TbExceptions() {
                //    CreatedAt = DateTime.UtcNow,
                //    Exception = ex.Message
                //});
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateAsync(TModel entity) {
            throw new NotImplementedException();
        }
    }

    public class TbTest : DbModelBase{
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class TestDbContext : DbContext {
        public TestDbContext(DbContextOptions<TestDbContext> context) : base(context) {

        }
        public DbSet<TbTest> TbTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TbTest>()
                .ToTable("tbtests", schema: "application");
        }
    }

    public class TbBase {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int RowVersion { get; set; }
    }
}
