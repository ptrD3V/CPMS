using System;
using System.Collections.Generic;

namespace CPMS.BL.Entities
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public decimal ManHour { get; set; }
        public decimal Time { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Time> TimeSpent { get; set; }
    }
}
