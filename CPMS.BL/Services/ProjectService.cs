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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectDTO> _logger;

        public ProjectService(IProjectRepository repository, IMapper mapper, ILogger<ProjectDTO> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(Project item)
        {
            try
            {
                var task = _mapper.Map<ProjectDTO>(item);
                _repository.Add(task);
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }
        }

        public void Delete(Project item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Project> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByID(id);
                var task = _mapper.Map<Project>(item);
                return task;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Address : {e}");
            }

            return null;
        }

        public void Update(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
