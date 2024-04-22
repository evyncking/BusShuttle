using System.ComponentModel.DataAnnotations;

namespace ManagerDashboard.Models
{
    public class StopModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Stop Name field is required.")]
        public string StopName { get; set; }
    }
}
