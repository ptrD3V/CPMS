using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    public class DeveloperFactory : BaseFactory<DeveloperDTO>, IDeveloperFactory
    {
        private readonly IDeveloperRepository _repository;
        private readonly IMapper _mapper;

        public DeveloperFactory(ManagementSystemContext ctx, IDeveloperRepository repository, IMapper mapper) :
            base(ctx)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Developer Create(DeveloperDTO item)
        {
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Developer>(item);
        }
    }
}
