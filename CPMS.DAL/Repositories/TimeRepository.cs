using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class TimeRepository : BaseRepository<TimeDTO>, ITimeRepository
    {
        public TimeRepository(ManagementSystemContext ctx, ILogger<TimeDTO> logger) :
            base(ctx, logger)
        { }
    }
}
