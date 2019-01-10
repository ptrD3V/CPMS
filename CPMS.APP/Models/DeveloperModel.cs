using CPMS.DAL.Common;

namespace CPMS.APP.Models
{
    public class DeveloperModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
