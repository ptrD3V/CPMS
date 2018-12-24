using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPMS.DAL.DAO
{

    [Table("Address", Schema = "cpms")]
    public class Address
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
