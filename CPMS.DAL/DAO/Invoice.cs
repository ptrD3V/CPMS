using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPMS.DAL.DAO
{
    class Invoice
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public decimal ManHour { get; set; }

        [Required]
        public decimal Time { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Time> TimeSpent { get; set; }
    }
}
