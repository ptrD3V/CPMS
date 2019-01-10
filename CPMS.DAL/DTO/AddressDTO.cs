using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Addresses", Schema = "pms")]
    public class AddressDTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int ZIP { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
