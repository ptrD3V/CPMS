using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class CommentRepository : BaseRepository<CommentDTO>, ICommentRepository
    {
        public CommentRepository(ManagementSystemContext ctx, ILogger<CommentDTO> logger) :
            base(ctx, logger)
        { }
    }
}
