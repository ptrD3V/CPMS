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

        public Customer Add(Customer item)
        {
            try
            {
                var customer = _mapper.Map<CustomerDTO>(item);
                var result = _factory.Create(customer);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Customer : {e}");
            }

            return null;
        }

        public async Task Delete(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                _repository.Delete(item);
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with delete Customer : {e}");
            }
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var users = await _repository.GetAllAsync();
            var result = users != null ? _mapper.Map<IEnumerable<Customer>>(users) : null;
            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByIDAsync(id);
                var result = _mapper.Map<Customer>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with find Customer : {e}");
            }

            return null;
        }

        public void Update(Customer item)
        {
            try
            {
                _repository.Update(_mapper.Map<CustomerDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Customer : {e}");
            }
        }
    }
}
