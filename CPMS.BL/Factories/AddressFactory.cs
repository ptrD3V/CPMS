using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    public class AddressFactory : BaseFactory<AddressDTO>, IAddressFactory
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressFactory(ManagementSystemContext ctx, IAddressRepository repository, IMapper mapper) :
            base(ctx)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Address Create(AddressDTO item)
        {
            var address = this.Identify(item);
            _repository.Add(address);
            _repository.Save();

            return _mapper.Map<Address>(address);
        }
    }
}
