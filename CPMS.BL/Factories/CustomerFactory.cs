using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Customer factory represents class that manage data from services to repository.
    /// </summary>
    public class CustomerFactory : BaseFactory<CustomerDTO>, ICustomerFactory
    {
        private readonly IBillingInfoFactory _billingInfoFactory;
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Customer factory.
        /// </summary>
        /// <param name="ctx">DB Context inherited from Base Facory</param>
        /// <param name="repository">Class type repository injection</param>
        /// <param name="mapper">Automapper injection</param>
        /// <param name="billingInfoFactory">Billing info factory injection</param>
        public CustomerFactory(ManagementSystemContext ctx, ICustomerRepository repository, IMapper mapper,
            IBillingInfoFactory billingInfoFactory) :
            base(ctx)
        {
            _billingInfoFactory = billingInfoFactory;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// This function manage data from service to repository pattern.
        /// There is also called creation of Billing info.
        /// </summary>
        /// <param name="item">Inserted object</param>
        /// <returns>Pre-mapped object</returns>
        public Customer Create(CustomerDTO item)
        {
            var billingInfo = _billingInfoFactory.Create(item.BillingInfo);
            item.BillingInfo = _mapper.Map<BillingInfoDTO>(billingInfo);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Customer>(item);
        }
    }
}
