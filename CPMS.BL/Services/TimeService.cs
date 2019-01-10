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
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repository;
        private readonly ITimeFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<TimeDTO> _logger;

        public TimeService(ITimeRepository repository, IMapper mapper, ITimeFactory factory, ILogger<TimeDTO> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _factory = factory;
            _logger = logger;
        }

        public Time Add(Time item)
        {
            try
            {
                var time = _mapper.Map<TimeDTO>(item);
                var result = _factory.Create(time);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Time : {e}");
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
                _logger.LogError($"There is a problem with delete Time : {e}");
            }
        }

        public async Task<IEnumerable<Time>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            var result = items != null ? _mapper.Map<IEnumerable<Time>>(items) : null;
            return result;
        }

        public async Task<Time> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByIDAsync(id);
                var result = _mapper.Map<Time>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with find Time : {e}");
            }

            return null;
        }

        public async Task<IEnumerable<Time>> GetByTask(int id)
        {
            var items = await _repository.FindByTask(id);
            var result = items != null ? _mapper.Map<IEnumerable<Time>>(items) : null;
            return result;
        }

        public void Update(Time item)
        {
            try
            {
                _repository.Update(_mapper.Map<TimeDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Time : {e}");
            }
        }
    }
}
