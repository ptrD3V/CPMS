using System;
using System.Collections.Generic;
using System.Text;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface IAddressFactory : IBaseFactory<AddressDTO>
    {
        Address Create(AddressDTO item);
    }
}
