using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace CPMS.BL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskDTO> _logger;

        public TaskService(ITaskRepository repository, IMapper mapper, ILogger<TaskDTO> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(TaskItem item)
        {
            try
            {
                var task = _mapper.Map<TaskDTO>(item);
                _repository.Add(task);
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public void Delete(TaskItem item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            try
            {
                var item = await _repository.GetAll();
                var address = _mapper.Map<IEnumerable<TaskItem>>(item);
                return address;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public async Task<TaskItem> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var task = _mapper.Map<TaskItem>(item);
                return task;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(TaskItem item)
        {
            throw new NotImplementedException();
        }
    }
}
