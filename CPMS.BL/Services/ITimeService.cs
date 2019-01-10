using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.BL.Entities;

namespace CPMS.BL.Services
{
    public interface ITimeService : IBaseService<Time>
    {
        Task<IEnumerable<Time>> GetByTask(int id);
    }
}
