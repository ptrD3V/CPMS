using System.Collections.Generic;
using System.Threading.Tasks;
using CPMS.GUI.Models;

namespace CPMS.GUI.Factories
{
    public interface ICustomerFactory : IBaseFactory<CustomerModel>
    {
        Task<IEnumerable<CustomerListModel>> GetCustomerList();
    }
}
