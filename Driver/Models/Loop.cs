using System.ComponentModel.DataAnnotations;

namespace Driver.Models
{
    public class Loop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoopName { get; set; }
    }
}
