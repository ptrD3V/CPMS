using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    public class ProjectFactory : BaseFactory<ProjectDTO>, IProjectFactory
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly IProjectRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ProjectFactory(ManagementSystemContext ctx, IProjectRepository repository, 
            ICustomerRepository customerRepository, IMapper mapper, ICustomerFactory customerFactory) :
            base(ctx)
        {
            _customerFactory = customerFactory;
            _repository = repository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Project> Create(ProjectDTO item)
        {
            var customer = await _customerRepository.GetByID(item.CustomerID);
            item.Customer = _mapper.Map<CustomerDTO>(customer);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Project>(item);
        }
    }
}
