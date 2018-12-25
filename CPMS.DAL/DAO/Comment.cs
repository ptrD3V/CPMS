using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DAO
{
    [Table("Comments", Schema = "cpms")]
    public class Comment
    {
        public int ID { get; set; }

        public string Text { get; set; }

        [Required]
        public int DeveloperID { get; set; }

        [Required]
        public int TaskID { get; set; }
    }
}
