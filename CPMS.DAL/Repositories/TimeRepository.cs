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
    public class TimeRepository : BaseRepository<TimeDTO>, ITimeRepository
    {
        public TimeRepository(ManagementSystemContext ctx, ILogger<TimeDTO> logger) :
            base(ctx, logger)
        { }

        public async Task<TimeDTO> GetByIDAsync(int id)
        {
            try
            {
                return await _ctx.Times.Include(d => d.Developer).Where(x => x.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(TimeDTO).FullName} by id : {e}");
            }

            return null;
        }

        public virtual async Task<IEnumerable<TimeDTO>> GetAllAsync()
        {
            try
            {
                return await _ctx.Times.Include("Developer").ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(TimeDTO).FullName} to list : {e}");
            }

            return null;
        }

        public virtual async Task<IEnumerable<TimeDTO>> FindByTask(int id)
        {
            try
            {
                return await _ctx.Times.Include("Developer").Where(x => x.TaskID == id).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(TimeDTO).FullName} to list : {e}");
            }

            return null;
        }
    }
}
