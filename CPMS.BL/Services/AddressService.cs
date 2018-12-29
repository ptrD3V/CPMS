using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace CPMS.BL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressDTO> _logger;

        public AddressService(IAddressRepository repository, IMapper mapper, ILogger<AddressDTO> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(Address item)
        {
            try
            {
                var address = _mapper.Map<AddressDTO>(item);
                _repository.Add(address);
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public void Delete(Address item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
