using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    public class TaskFactory : BaseFactory<TaskDTO>, ITaskFactory
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public TaskFactory(ManagementSystemContext ctx, ITaskRepository repository, IMapper mapper) :
            base(ctx)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public TaskItem Create(TaskDTO item)
        {
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<TaskItem>(item);
        }
    }
}
