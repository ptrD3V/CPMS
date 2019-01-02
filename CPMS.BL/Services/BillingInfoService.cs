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

        public void Add(BillingInfo item)
        {
            try
            {
                var billingInfo = _mapper.Map<BillingInfoDTO>(item);
                var result = _factory.Create(billingInfo);
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public void Delete(BillingInfo item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BillingInfo>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BillingInfo> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var billingInfo = _mapper.Map<BillingInfo>(item);
                return billingInfo;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(BillingInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
