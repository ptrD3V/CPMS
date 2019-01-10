using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Times", Schema = "pms")]
    public class TimeDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int TaskID { get; set; }

        public virtual TaskDTO Task { get; set; }

        [Required]
        public int DeveloperID { get; set; }

        public virtual DeveloperDTO Developer { get; set; }

        public int? InvoiceID { get; set; }

        public virtual InvoiceDTO Invoice { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? Close { get; set; }
    }
}
