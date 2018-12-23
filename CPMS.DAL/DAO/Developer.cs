using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPMS.DAL.DAO
{
    class Developer : Person
    {
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
