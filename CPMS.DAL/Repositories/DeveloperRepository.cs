using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class DeveloperRepository : RepositoryBase<DeveloperDTO>, IDeveloperRepository
    {
        public DeveloperRepository(ManagementSystemContext ctx, ILogger<DeveloperDTO> logger) :
            base(ctx, logger)
        { }
    }
}
