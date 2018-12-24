using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPMS.DAL.DAO
{
    [Table("Task", Schema = "cpms")]
    public class Task
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Points Point { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public DateTime StarDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public enum Points
    {
        VeryLow = 1,
        Low = 3,
        Intermediate = 5,
        Hard = 7,
        VeryHard = 9
    }

    public enum Type
    {
        Feature,
        Error
    }

    public enum Status
    {
        Active,
        Delayed,
        Done
    }
}
