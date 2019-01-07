using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CPMS.BL.Entities;

namespace CPMS.BL.Services
{
    public interface IDeveloperService : IBaseService<Developer>
    {
        Developer Authenticate(string username, string password);
        Developer Add(Developer user, string password);
    }
}
