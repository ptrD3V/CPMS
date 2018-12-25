using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DAO
{
    [Table("Customers", Schema = "cpms")]
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public virtual BillingInfo BillingInfo { get; set; }
    }
}
