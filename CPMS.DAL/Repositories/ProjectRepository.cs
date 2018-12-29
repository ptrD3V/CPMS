using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class ProjectRepository : RepositoryBase<ProjectDTO>, IProjectRepository
    {
        public ProjectRepository(ManagementSystemContext ctx, ILogger<ProjectDTO> logger) :
            base(ctx, logger)
        { }
    }
}
