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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IProjectFactory _factory;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectDTO> _logger;

        public ProjectService(IProjectRepository repository, IMapper mapper, ILogger<ProjectDTO> logger, IProjectFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _factory = factory;
        }

        public Project Add(Project item)
        {
            try
            {
                var project = _mapper.Map<ProjectDTO>(item);
                var result = _factory.Create(project);
                return result.Result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with save Project : {e}");
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
                _logger.LogError($"There is a problem with delete Project : {e}");
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var projects = await _repository.GetAllAsync();
            var result = projects != null ? _mapper.Map<IEnumerable<Project>>(projects) : null;
            return result;
        }

        public async Task<Project> GetById(int id)
        {
            try
            {
                var item = await _repository.GetByIDAsync(id);
                var result = _mapper.Map<Project>(item);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with find Project : {e}");
            }

            return null;
        }

        public void Update(Project item)
        {
            try
            {
                _repository.Update(_mapper.Map<ProjectDTO>(item));
                _repository.Save();
            }
            catch (Exception e)
            {
                _logger.LogError($"There is a problem with update Project : {e}");
            }
        }
    }
}
