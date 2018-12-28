using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Projects", Schema = "cpms")]
    public class ProjectDTO
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

        public virtual ICollection<TaskDTO> Tasks { get; set; }
    }
}
