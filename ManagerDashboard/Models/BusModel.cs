using System.ComponentModel.DataAnnotations;

namespace ManagerDashboard.Models
{
    public class BusModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Bus Number field is required.")]
        public string BusNumber { get; set; }
    }
}
