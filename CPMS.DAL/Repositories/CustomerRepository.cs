using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(ManagementSystemContext ctx, ILogger<CustomerDTO> logger) :
            base(ctx, logger)
        { }
    }
}
