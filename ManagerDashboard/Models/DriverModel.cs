using System.ComponentModel.DataAnnotations;

namespace ManagerDashboard.Models
{
    public class DriverModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set;}
    }
}
