using System.Collections.Generic;

namespace CPMS.APP.Models
{
    public class InvoiceModel
    {
        public CustomerModel Customer { get; set; }
        public IList<TaskModel> Tasks { get; set; }
    }
}
