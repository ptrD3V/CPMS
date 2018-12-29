using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using CPMS.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task = System.Threading.Tasks.Task;

namespace CPMS.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private ManagementSystemContext _ctx;
        private ILogger<T> _logger;

        public RepositoryBase(ManagementSystemContext ctx, ILogger<T> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public RepositoryBase(ManagementSystemContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Method adds item of type T to the dbSet<T>.
        /// There is used incrementation of ID by reflection.
        /// </summary>
        /// <param name="item">Item of type T</param>
        public void Add(T item)
        {
            try
            {
                Type type = item.GetType();
                object obj = Activator.CreateInstance(type);
                obj = item;
                PropertyInfo prop = type.GetProperty("ID");
                Type propertyType = prop.PropertyType;
                TypeCode typeCode = Type.GetTypeCode(propertyType);
                int oldID = (int)prop.GetValue(obj, null);
                if (prop != null && oldID <= 0)
                {
                    int value = _ctx.Set<T>().Count() + 1;
                    prop.SetValue(obj, value, null);
                }
                _ctx.Set<T>().Add((T)obj);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with add {typeof(T).FullName} : {e}");
            }
        }

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

        public async Task<T> GetByID(int id)
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
