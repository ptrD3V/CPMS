using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.GUI.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
