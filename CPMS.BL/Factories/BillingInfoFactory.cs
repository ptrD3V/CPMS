using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Billing info factory represents class that manage data from services to repository.
    /// </summary>
    public class BillingInfoFactory : BaseFactory<BillingInfoDTO>, IBillingInfoFactory
    {
        private readonly IAddressFactory _addressFactory;
        private readonly IBillingInfoRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Billing factory.
        /// </summary>
        /// <param name="ctx">DB Context inherited from Base Facory</param>
        /// <param name="repository">Class type repository injection</param>
        /// <param name="mapper">Automapper injection</param>
        /// <param name="addressFactory">Address factory injection</param>
        public BillingInfoFactory(ManagementSystemContext ctx, IBillingInfoRepository repository, IMapper mapper, IAddressFactory addressFactory) :
            base(ctx)
        {
            _addressFactory = addressFactory;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// This function manage data from service to repository pattern.
        /// There is also called creation of Address
        /// </summary>
        /// <param name="item">Inserted object</param>
        /// <returns>Pre-mapped object</returns>
        public BillingInfo Create(BillingInfoDTO item)
        {
            var address = _addressFactory.Create(item.Address);
            item.Address = _mapper.Map<AddressDTO>(address);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<BillingInfo>(item);
        }
    }
}
