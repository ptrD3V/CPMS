﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CPMS.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerDTO>, ICustomerRepository
    {
        public CustomerRepository(ManagementSystemContext ctx, ILogger<CustomerDTO> logger) :
            base(ctx, logger)
        { }

        public override async Task<CustomerDTO> GetByID(int id)
        {
            try
            {
                return await _ctx.Customers.Include(i => i.BillingInfo).ThenInclude(a => a.Address).Where(x => x.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Problem with get {typeof(CustomerDTO).FullName} by id : {e}");
            }

            return null;
        }
    }
}
