using System;
using System.Collections.Generic;
using System.Text;

namespace CPMS.BL.Entities
{
    public class Time
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int PersonID { get; set; }
        public int? InvoiceID { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Close { get; set; }
    }
}
