using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DAO
{
    [Table("Times", Schema = "cpms")]
    public class Time
    {
        public int ID { get; set; }

        [Required]
        public int TaskID { get; set; }

        [Required]
        public int PersonID { get; set; }

        public int? InvoiceID { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? Close { get; set; }
    }
}
