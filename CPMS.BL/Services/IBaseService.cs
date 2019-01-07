using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMS.BL.Services
{
    public interface IBaseService<T>
    {
        T Add(T item);
        Task Delete(int id);
        void Update(T item);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
