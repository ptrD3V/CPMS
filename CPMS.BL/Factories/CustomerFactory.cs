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
    public class CustomerFactory : BaseFactory<CustomerDTO>, ICustomerFactory
    {
        private readonly IBillingInfoFactory _billingInfoFactory;
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerFactory(ManagementSystemContext ctx, ICustomerRepository repository, IMapper mapper,
            IBillingInfoFactory billingInfoFactory) :
            base(ctx)
        {
            _billingInfoFactory = billingInfoFactory;
            _repository = repository;
            _mapper = mapper;
        }

        public Customer Create(CustomerDTO item)
        {
            var billingInfo = _billingInfoFactory.Create(item.BillingInfo);
            item.BillingInfo = _mapper.Map<BillingInfoDTO>(billingInfo);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Customer>(item);
        }
    }
}
