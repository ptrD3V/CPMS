using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CPMS.DAL.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> FindByConditionAync(Expression<Func<T, bool>> expression);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
