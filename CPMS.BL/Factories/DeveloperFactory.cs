﻿using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Developer factory represents class that manage data from services to repository.
    /// </summary>
    public class DeveloperFactory : BaseFactory<DeveloperDTO>, IDeveloperFactory
    {
        private readonly IDeveloperRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Developer factory.
        /// </summary>
        /// <param name="ctx">DB Context inherited from Base Facory</param>
        /// <param name="repository">Class type repository injection</param>
        /// <param name="mapper">Automapper injection</param>
        public DeveloperFactory(ManagementSystemContext ctx, IDeveloperRepository repository, IMapper mapper) :
            base(ctx)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// This function manage data from service to repository pattern.
        /// </summary>
        /// <param name="item">Inserted object</param>
        /// <returns>Pre-mapped object</returns>
        public Developer Create(DeveloperDTO item)
        {
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Developer>(item);
        }
    }
}
