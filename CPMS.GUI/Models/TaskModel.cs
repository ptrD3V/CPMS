using CPMS.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.GUI.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Points Point { get; set; }
        public TaskType Type { get; set; }
        public int ProjectID { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
    }
}
