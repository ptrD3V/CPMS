using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CPMS.DAL.DAO
{
    class Comment
    {
        [Key]
        public int ID { get; set; }

        public string Text { get; set; }

        [Required]
        public int DeveloperID { get; set; }

        [Required]
        public int TaskID { get; set; }
    }
}
