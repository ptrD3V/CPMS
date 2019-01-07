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
    public class BillingInfoService : IBillingInfoService
    {
        private readonly IBillingInfoRepository _repository;
        private readonly IBillingInfoFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<BillingInfoDTO> _logger;

        public BillingInfoService(IBillingInfoRepository repository, IMapper mapper, ILogger<BillingInfoDTO> logger, 
            IBillingInfoFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _factory = factory;
        }

        public BillingInfo Add(BillingInfo item)
        {
            try
            {
                var billingInfo = _mapper.Map<BillingInfoDTO>(item);
                var result = _factory.Create(billingInfo);
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
                _logger.LogError($"There is a problem with delete BillingInfo : {e}");
            }
        }

        public Task<IEnumerable<BillingInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BillingInfo> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByIDAsync(id);
                var result = _mapper.Map<BillingInfo>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(BillingInfo item)
        {
            try
            {
                _repository.Update(_mapper.Map<BillingInfoDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update BillingInfo : {e}");
            }
        }
    }
}
