using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.BL.Factories;
using CPMS.DAL.DTO;

using CPMS.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace CPMS.BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerDTO> _logger;

        public CustomerService(ICustomerRepository repository, IMapper mapper, ILogger<CustomerDTO> logger, 
            ICustomerFactory factory
        )
        {
            _repository = repository;
            _factory = factory;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(Customer item)
        {
            try
            {
                var customer = _mapper.Map<CustomerDTO>(item);
                var result = _factory.Create(customer);
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public void Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var address = _mapper.Map<Customer>(item);
                return address;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
