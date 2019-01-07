using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class BillingInfoRepository : BaseRepository<BillingInfoDTO>, IBillingInfoRepository
    {
        public BillingInfoRepository(ManagementSystemContext ctx, ILogger<BillingInfoDTO> logger) :
            base(ctx, logger)
        { }

        public async Task<BillingInfoDTO> GetByIDAsync(int id)
        {
            try
            {
                return await _ctx.BillingInfos.Include("Address").Where(x => x.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(BillingInfoDTO).FullName} by id : {e}");
            }

            return null;
        }
    }
}
