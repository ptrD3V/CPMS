using CPMS.BL.Entities;
using System.Threading.Tasks;

namespace CPMS.BL.Services
{
    public interface IAddressService
    {
        Task AddAddress(Address item);
        Task<Address> GetPersonAddress(int id);
    }
}
