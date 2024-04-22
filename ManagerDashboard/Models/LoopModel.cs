using System.ComponentModel.DataAnnotations;

namespace ManagerDashboard.Models
{
    public class LoopModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Loop Name field is required.")]
        public string LoopName { get; set; }
    }
}
