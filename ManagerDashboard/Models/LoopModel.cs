using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerDashboard.Models
{
    public class LoopModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Loop Name field is required.")]
        public string LoopName { get; set; }
    }
}
