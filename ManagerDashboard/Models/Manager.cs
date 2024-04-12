using System.ComponentModel.DataAnnotations;

namespace ManagerDashboard.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
