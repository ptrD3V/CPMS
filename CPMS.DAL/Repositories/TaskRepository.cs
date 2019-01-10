using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class TaskRepository : BaseRepository<TaskDTO>, ITaskRepository
    {
        public TaskRepository(ManagementSystemContext ctx, ILogger<TaskDTO> logger) :
            base(ctx, logger)
        { }
    }
}
