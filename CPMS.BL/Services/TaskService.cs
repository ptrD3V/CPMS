using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.BL.Factories;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace CPMS.BL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ITimeRepository _timeRepository;
        private readonly ITaskFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskDTO> _logger;

        public TaskService(ITaskRepository repository, ITimeRepository timeRepository, IMapper mapper, ITaskFactory factory, ILogger<TaskDTO> logger)
        {
            _repository = repository;
            _timeRepository = timeRepository;
            _mapper = mapper;
            _factory = factory;
            _logger = logger;
        }

        public TaskItem Add(TaskItem item)
        {
            try
            {
                var task = _mapper.Map<TaskDTO>(item);
                var result = _factory.Create(task);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Task : {e}");
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
                _logger.LogError($"There is a problem with delete Task : {e}");
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            var tasks = await _repository.GetAll();
            var result = tasks != null ? _mapper.Map<IEnumerable<TaskItem>>(tasks) : null;
            return result;
        }

        public async Task<TaskItem> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var result = _mapper.Map<TaskItem>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with find Task : {e}");
            }

            return null;
        }

        public async Task<IEnumerable<TaskItem>> GetByProject(int id)
        {
            var items = await _repository.FindByConditionAync(x => x.ProjectID == id);
            var result = items != null ? _mapper.Map<IEnumerable<TaskItem>>(items) : null;
            return result;
        }

        public async Task<IEnumerable<Time>> GetTime(int id)
        {
            var items = await _repository.FindByConditionAync(x => x.ProjectID == id);
            var ids = items.Select(x => x.ID).ToList();
            var times = await _timeRepository.FindByConditionAync(x => ids.Contains(x.TaskID));
            var result = items != null ? _mapper.Map<IEnumerable<Time>>(times) : null;
            return result;
        }

        public void Update(TaskItem item)
        {
            try
            {
                _repository.Update(_mapper.Map<TaskDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Task : {e}");
            }
        }
    }
}
