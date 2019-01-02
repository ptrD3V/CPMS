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
    public class BillingInfoFactory : BaseFactory<BillingInfoDTO>, IBillingInfoFactory
    {
        private readonly IAddressFactory _addressFactory;
        private readonly IBillingInfoRepository _repository;
        private readonly IMapper _mapper;

        public BillingInfoFactory(ManagementSystemContext ctx, IBillingInfoRepository repository, IMapper mapper, IAddressFactory addressFactory) :
            base(ctx)
        {
            _addressFactory = addressFactory;
            _repository = repository;
            _mapper = mapper;
        }

        public BillingInfo Create(BillingInfoDTO item)
        {
            var address = _addressFactory.Create(item.Address);
            item.Address = _mapper.Map<AddressDTO>(address);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<BillingInfo>(item);
        }
    }
}
