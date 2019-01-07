using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Repositories
{
    public interface IProjectRepository : IBaseRepository<ProjectDTO>
    {
        Task<ProjectDTO> GetByIDAsync(int id);
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
    }
}
