using System;
using System.Collections.Generic;
using System.Text;

namespace CPMS.BL.Entities
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
