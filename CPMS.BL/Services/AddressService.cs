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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IAddressFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressDTO> _logger;

        public AddressService(IAddressRepository repository, IMapper mapper, ILogger<AddressDTO> logger, IAddressFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _factory = factory;
        }

        public Address Add(Address item)
        {
            try
            {
                var address = _mapper.Map<AddressDTO>(item);
                var result = _factory.Create(address);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
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
                _logger.LogError($"There is a problem with delete Address : {e}");
            }
        }

        public Task<IEnumerable<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var address = _mapper.Map<Address>(item);
                return address;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(Address item)
        {
            try
            {
                _repository.Update(_mapper.Map<AddressDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Address : {e}");
            }
        }
    }
}
