using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.APP.Models
{
    public class BillingInfoModel
    {
        public string CompanyName { get; set; }
        public AddressModel Address { get; set; }
        public string ICO { get; set; }
        public string DIC { get; set; }
        public string IBAN { get; set; }
    }
}
