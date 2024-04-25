using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerDashboard.Models
{
    public class StopModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Stop Name field is required.")]
        public string StopName { get; set; }
    }
}
