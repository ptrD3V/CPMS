using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Invoices", Schema = "cpms")]
    public class InvoiceDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal ManHour { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Time { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<TimeDTO> TimeSpent { get; set; }
    }
}
