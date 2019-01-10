using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface IDeveloperFactory : IBaseFactory<DeveloperDTO>
    {
        Developer Create(DeveloperDTO item);
    }
}
