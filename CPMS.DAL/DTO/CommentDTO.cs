using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Comments", Schema = "cpms")]
    public class CommentDTO
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
