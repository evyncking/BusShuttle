using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerDashboard.Models
{
    public class BusModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Bus Number field is required.")]
        public string BusNumber { get; set; }
    }
}
