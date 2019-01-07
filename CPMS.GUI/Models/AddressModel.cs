using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.GUI.Models
{
    public class AddressModel
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
