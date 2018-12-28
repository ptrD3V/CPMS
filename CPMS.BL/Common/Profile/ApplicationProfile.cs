using System;
using System.Collections.Generic;
using System.Text;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Common.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}
