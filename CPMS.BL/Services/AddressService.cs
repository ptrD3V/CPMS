using System;
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
        private readonly ILogger _logger;

        public AddressService(IAddressRepository repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAddress(Address item)
        {
            try
            {
                var address = _mapper.Map<AddressDTO>(item);
                _repository.Add(address);
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public async Task<Address> GetPersonAddress(int id)
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
    }
}
