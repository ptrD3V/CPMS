using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Repositories
{
    public interface ICustomerRepository : IBaseRepository<CustomerDTO>
    {
        Task<CustomerDTO> GetByIDAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
    }
}
