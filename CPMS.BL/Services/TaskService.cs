using System;
using System.Collections.Generic;
using System.Text;
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
        private readonly ITaskFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskDTO> _logger;

        public TaskService(ITaskRepository repository, IMapper mapper, ITaskFactory factory, ILogger<TaskDTO> logger)
        {
            _repository = repository;
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
