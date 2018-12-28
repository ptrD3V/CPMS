using System;
using System.Collections.Generic;
using System.Text;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class AddressRepository : RepositoryBase<AddressDTO>, IAddressRepository
    {
        public AddressRepository(ManagementSystemContext ctx, ILogger logger) :
            base(ctx, logger)
        { }
    }
}
