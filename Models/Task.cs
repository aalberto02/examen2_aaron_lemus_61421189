using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examen2_aaron_lemus_61421189.Models
{
    [Table("task")]
    public class Task
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Tittle { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
