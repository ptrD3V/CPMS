using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<ProjectDTO>, IProjectRepository
    {
        public ProjectRepository(ManagementSystemContext ctx, ILogger<ProjectDTO> logger) :
            base(ctx, logger)
        { }

        public async Task<ProjectDTO> GetByIDAsync(int id)
        {
            try
            {
                return await _ctx.Projects.Include(c => c.Customer).ThenInclude(b => b.BillingInfo).Where(x => x.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(ProjectDTO).FullName} by id : {e}");
            }

            return null;
        }

        public virtual async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            try
            {
                return await _ctx.Projects.Include("Customer").ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(ProjectDTO).FullName} to list : {e}");
            }

            return null;
        }
    }
}
