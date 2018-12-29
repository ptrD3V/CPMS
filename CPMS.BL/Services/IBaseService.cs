using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMS.BL.Services
{
    public interface IBaseService<T>
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
