using System;

namespace CPMS.APP.Models
{
    public class TimeModel
    {
        public int TaskID { get; set; }
        public int DeveloperID { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Close { get; set; }
    }
}
