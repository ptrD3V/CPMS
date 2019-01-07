using CPMS.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Tasks", Schema = "cpms")]
    public class TaskDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Points Point { get; set; }

        [Required]
        public TaskType Type { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public DateTime StarDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
    }
}
