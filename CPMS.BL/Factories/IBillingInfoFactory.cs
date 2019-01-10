using CPMS.BL.Entities;
using CPMS.DAL.DTO;

namespace CPMS.BL.Factories
{
    public interface IBillingInfoFactory : IBaseFactory<BillingInfoDTO>
    {
        BillingInfo Create(BillingInfoDTO item);
    }
}
