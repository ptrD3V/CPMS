using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPMS.DAL.DAO
{
    class Project
    {
        [Key]
        public int ID { get; set; }

        [Required]
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
