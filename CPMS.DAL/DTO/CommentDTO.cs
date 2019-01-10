using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.DAL.DTO
{
    [Table("Comments", Schema = "pms")]
    public class CommentDTO
    {
        [Key]
        public int ID { get; set; }

        public string Text { get; set; }

        [Required]
        public int DeveloperID { get; set; }

        public virtual DeveloperDTO Developer { get; set; }

        [Required]
        public int TaskID { get; set; }

        public virtual TaskDTO Task{ get; set; }
    }
}
