using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class BillingInfoRepository : RepositoryBase<BillingInfoDTO>, IBillingInfoRepository
    {
        public BillingInfoRepository(ManagementSystemContext ctx, ILogger<BillingInfoDTO> logger) :
            base(ctx, logger)
        { }
    }
}
