using CPMS.BL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMS.BL.Services
{
    public interface ITaskService : IBaseService<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetByProject(int id);
        Task<IEnumerable<Time>> GetTime(int id);
    }
}
