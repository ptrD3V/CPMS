using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPMS.DAL.DAO
{

    class Customer : Person
    {
        public virtual BillingInfo BillingInfo { get; set; }
    }
}
