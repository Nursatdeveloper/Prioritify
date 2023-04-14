using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Prioritify.Data.DbContexts;
using Prioritify.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Repositories {
    public interface IPrioritifyRepository<T> where T : class {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T entity);
    }
    public class PrioritifyRepository<T>: IPrioritifyRepository<T> where T : class {
        private readonly PrioritifyDbContext _context;
        private readonly ISystemRepository<TbExceptions> _exceptions;
        private readonly ISystemRepository<TbLogs> _logs;

        public PrioritifyRepository(PrioritifyDbContext context, ISystemRepository<TbLogs> logs, ISystemRepository<TbExceptions> exceptions) {
            _context = context;
            _logs = logs;
            _exceptions = exceptions;
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            try {
                var result = await _context.Set<T>().ToListAsync();
                return result;
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter) {
            try {
                var entity = await _context.Set<T>().FindAsync(filter);
                return entity;
            } catch(Exception ex) {
                await _exceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                await _logs.InsertAsync(new TbLogs() {
                    Type = "Error",
                    Message = $"Exception occured at PrioritifyRepository.GetAsync method! Timestamp: {DateTime.UtcNow}"
                });
                throw new Exception(ex.Message);
            }
        }

        

        public async Task InsertAsync(T entity) {
            try {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            } catch(Exception ex) {
                await _exceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }
    }
}
