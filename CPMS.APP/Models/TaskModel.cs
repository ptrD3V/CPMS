using CPMS.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.APP.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Points Point { get; set; }
        public TaskType Type { get; set; }
        public int ProjectID { get; set; }
        public DateTime StarDate { get; set; }
    }
}
