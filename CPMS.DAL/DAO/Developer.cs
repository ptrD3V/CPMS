using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DAO
{
    [Table("Developers", Schema = "cpms")]
    public class Developer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public Role Role { get; set; }
    }

    public enum Role
    {
        Tester,
        Developer,
        Manager
    }
}
