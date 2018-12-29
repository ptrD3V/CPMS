using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class TaskRepository : RepositoryBase<TaskDTO>, ITaskRepository
    {
        public TaskRepository(ManagementSystemContext ctx, ILogger<TaskDTO> logger) :
            base(ctx, logger)
        { }
    }
}
