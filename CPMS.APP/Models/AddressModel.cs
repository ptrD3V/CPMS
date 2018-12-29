using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.APP.Models
{
    public class AddressModel
    {
        public string Street { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
