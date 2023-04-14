using Microsoft.Extensions.DependencyInjection;
using Prioritify.Data.DbContexts;
using Prioritify.Data.Tables;
using System.Linq.Expressions;


namespace Prioritify.Data.Repositories {
    public interface IUserRepository<T> where T : class {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
    public class UserRepository<T>: IUserRepository<T> where T : class {
        private readonly UserDbContext _context;
        private readonly ISystemRepository<TbExceptions> _tbExceptions;

        public UserRepository(UserDbContext context,  ISystemRepository<TbExceptions> tbExceptions) {
            _context= context;  
            _tbExceptions= tbExceptions;
        }
        public async Task DeleteAsync(T entity) {
            try {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            } catch(Exception ex) {
                await _tbExceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter) {
            try {
                var entity = await _context.Set<T>().FindAsync(filter);
                return entity;
            } catch(Exception ex) {
                await _tbExceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> InsertAsync(T entity) {
            try {
                var createdObject = await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return createdObject.Entity;
            } catch(Exception ex) {
                await _tbExceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(T entity) {
            try {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            } catch(Exception ex) {
                await _tbExceptions.InsertAsync(new TbExceptions() {
                    CreatedAt = DateTime.UtcNow,
                    Exception = ex.Message
                });
                throw new Exception(ex.Message);
            }
        }
    }

    public static class UserRepositorExtensions {
        public static IServiceCollection AddUserRepositories(this IServiceCollection services) {
            services.AddScoped<IUserRepository<TbUsers>, UserRepository<TbUsers>>();    
            services.AddScoped<IUserRepository<TbAccounts>, UserRepository<TbAccounts>>();    
            services.AddScoped<IUserRepository<TbUserRoles>, UserRepository<TbUserRoles>>();    
            services.AddScoped<IUserRepository<TbRoles>, UserRepository<TbRoles>>();
            return services;
        }
    }
}
