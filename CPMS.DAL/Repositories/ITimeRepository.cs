using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Repositories
{
    public interface ITimeRepository : IBaseRepository<TimeDTO>
    {
        Task<TimeDTO> GetByIDAsync(int id);
        Task<IEnumerable<TimeDTO>> GetAllAsync();
        Task<IEnumerable<TimeDTO>> FindByTask(int id);
    }
}
