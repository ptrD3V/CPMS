﻿using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Address factory represents class that manage data from services to repository.
    /// </summary>
    public class AddressFactory : BaseFactory<AddressDTO>, IAddressFactory
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Address factory.
        /// </summary>
        /// <param name="ctx">DB Context inherited from Base Facory</param>
        /// <param name="repository">Class type repository injection</param>
        /// <param name="mapper">Automapper injection</param>
        public AddressFactory(ManagementSystemContext ctx, IAddressRepository repository, IMapper mapper) :
            base(ctx)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// This function manage data from service to repository pattern.
        /// </summary>
        /// <param name="item">Inserted object</param>
        /// <returns>Pre-mapped object</returns>
        public Address Create(AddressDTO item)
        {
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Address>(item);
        }
    }
}
