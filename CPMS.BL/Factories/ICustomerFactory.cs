using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface ICustomerFactory : IBaseFactory<CustomerDTO>
    {
        Customer Create(CustomerDTO item);
    }
}
