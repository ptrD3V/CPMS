using System;

namespace CPMS.GUI.Models
{
    public class TimeModel
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int DeveloperID { get; set; }
        public virtual DeveloperModel Developer { get; set; }
        public int? InvoiceID { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Close { get; set; }

        public double TotalTime
        {
            get => Close.Value.Subtract(Start).TotalHours;
        }
    }
}
