using Prioritify.Data.DbContexts;
using System.Linq.Expressions;

namespace Prioritify.Data.Repositories {
    public interface ISystemRepository<T> where T : class {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task InsertAsync(T entity);
    }
    public class SystemRepository<T>: ISystemRepository<T> where T : class {
        private readonly SystemDbContext _context;
        public SystemRepository(SystemDbContext context) {
            _context = context;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter) {
            try {
                var entity = await _context.Set<T>().FindAsync(filter);
                return entity;
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertAsync(T entity) {
            try {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
