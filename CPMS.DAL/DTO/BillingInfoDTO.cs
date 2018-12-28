﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("BillingInfos", Schema = "cpms")]
    public class BillingInfoDTO
    {
        public int ID { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public virtual AddressDTO Address { get; set; }

        [Required]
        public string ICO { get; set; }

        [Required]
        public string DIC { get; set; }

        [Required]
        [StringLength(35)]
        public string IBAN { get; set; }
    }
}