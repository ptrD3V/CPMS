using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Repositories
{
    public interface IBillingInfoRepository : IBaseRepository<BillingInfoDTO>
    {
        Task<BillingInfoDTO> GetByIDAsync(int id);
    }
}
