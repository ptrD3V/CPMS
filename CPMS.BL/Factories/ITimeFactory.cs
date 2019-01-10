using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface ITimeFactory : IBaseFactory<TimeDTO>
    {
        Time Create(TimeDTO item);
    }
}
