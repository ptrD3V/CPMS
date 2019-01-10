using CPMS.DAL.Context;
using CPMS.DAL.DTO;

namespace CPMS.DAL.Repositories
{
    public class AddressRepository : BaseRepository<AddressDTO>, IAddressRepository
    {
        public AddressRepository(ManagementSystemContext ctx) :
            base(ctx)
        { }
    }
}
