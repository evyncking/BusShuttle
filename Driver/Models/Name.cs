using System.ComponentModel.DataAnnotations;

namespace Driver.Models
{
    public class Name
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
    }
}
