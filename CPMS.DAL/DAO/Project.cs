using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DAO
{
    [Table("Projects", Schema = "cpms")]
    public class Project
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public DateTime StarDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
