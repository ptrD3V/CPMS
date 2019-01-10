using System.Threading.Tasks;
using AutoMapper;
using CPMS.BL.Entities;
using CPMS.DAL.Context;
using CPMS.DAL.DTO;
using CPMS.DAL.Repositories;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Project factory represents class that manage data from services to repository.
    /// </summary>
    public class ProjectFactory : BaseFactory<ProjectDTO>, IProjectFactory
    {
        private readonly IProjectRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Developer factory.
        /// </summary>
        /// <param name="ctx">DB Context inherited from Base Facory</param>
        /// <param name="repository">Class type repository injection</param>
        /// <param name="customerRepository">Customer repository injection</param>
        /// <param name="mapper">Automapper injection</param>
        public ProjectFactory(ManagementSystemContext ctx, IProjectRepository repository, 
            ICustomerRepository customerRepository, IMapper mapper) :
            base(ctx)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// This function manage data from service to repository pattern.
        /// </summary>
        /// <param name="item">Inserted object</param>
        /// <returns>Pre-mapped object</returns>
        public async Task<Project> Create(ProjectDTO item)
        {
            var customer = await _customerRepository.GetByID(item.CustomerID);
            item.Customer = _mapper.Map<CustomerDTO>(customer);
            _repository.Add(item);
            _repository.Save();

            return _mapper.Map<Project>(item);
        }
    }
}
