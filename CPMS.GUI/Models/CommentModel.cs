using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.GUI.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int DeveloperID { get; set; }
        public int TaskID { get; set; }
    }
}
