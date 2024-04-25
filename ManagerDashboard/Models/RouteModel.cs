using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerDashboard.Models
{
    public class RouteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LoopId { get; set; }

        [Required]
        public int StopId { get; set; }

        [Required]
        public int Position { get; set; }  // Represents the order of the route

        [ForeignKey("LoopId")]
        public LoopModel Loop { get; set; }  // Navigation property

        [ForeignKey("StopId")]
        public StopModel Stop { get; set; }  // Navigation property

        [NotMapped] // This property is not mapped to the database
        public string LoopName { get; set; }  // Add this property

        [NotMapped] // This property is not mapped to the database
        public string StopName { get; set; }  // Add this property
    }


}
