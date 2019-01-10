using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CPMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    /// <summary>
    /// Generic base Repository define global actions for all repositories.
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ManagementSystemContext _ctx;
        protected ILogger<T> _logger;

        /// <summary>
        /// Constructor injects dependencies, that are shared with all repositories
        /// </summary>
        /// <param name="ctx">DB Context</param>
        /// <param name="logger">Logger</param>
        public BaseRepository(ManagementSystemContext ctx, ILogger<T> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public BaseRepository(ManagementSystemContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Method adds item of type T to the dbSet<T>.
        /// </summary>
        /// <param name="item">Item of type T</param>
        public void Add(T item)
        {
            try
            {
                _ctx.Set<T>().Add(item);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with add {typeof(T).FullName} : {e}");
            }
        }

        /// <summary>
        /// Method update model T in DbSet<T>
        /// </summary>
        /// <param name="item">Item of type T</param>
        public void Update(T item)
        {
            try
            {
                _ctx.Set<T>().Update(item);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with update {typeof(T).FullName} : {e}");
            }
        }

        /// <summary>
        /// Method remove model T from DbSet<T>
        /// </summary>
        /// <param name="item">Item of type T</param>
        public void Delete(T item)
        {
            try
            {
                _ctx.Set<T>().Remove(item);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with remove {typeof(T).FullName} : {e}");
            }
        }

        /// <summary>
        /// Method get collection from DbSet<T>
        /// </summary>
        /// <returns>Collection of items type of T</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _ctx.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get list of {typeof(T).FullName} : {e}");
            }

            return null;
        }

        /// <summary>
        /// Method returns single model from DbSet<T>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single item type of T</returns>
        public virtual async Task<T> GetByID(int id)
        {
            try
            {
                return await _ctx.Set<T>().FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(T).FullName} by id : {e}");
            }

            return null;
        }

        /// <summary>
        /// Method that provide LINQ query on DbSet<T>
        /// </summary>
        /// <param name="expression">LINQ where espression</param>
        /// <returns>Collection of items type of T</returns>
        public async Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _ctx.Set<T>().Where(expression).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(T).FullName} by expression : {e}");
            }

            return null;
        }

        /// <summary>
        /// Method that save changes on DbSet<T>
        /// </summary>
        public void Save()
        {
            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with save SET {typeof(T).Name} : {e}");
            }
            
        }
    }
}
