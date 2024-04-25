using System.ComponentModel.DataAnnotations;

namespace Driver.Models
{
    public class BusNumber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Number { get; set; }
    }
}
