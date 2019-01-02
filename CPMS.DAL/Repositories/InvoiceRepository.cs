using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class InvoiceRepository : BaseRepository<InvoiceDTO>, IInvoiceRepository
    {
        public InvoiceRepository(ManagementSystemContext ctx, ILogger<InvoiceDTO> logger) :
            base(ctx, logger)
        { }
    }
}
