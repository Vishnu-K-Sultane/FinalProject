using FinalProject.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.UI.Models
{
    public class Ambulance
    {
        [Column("AmbulanceId")]
        public Guid AmbulanceId { get; set; }
        public string? VehicleNumber { get; set; }
        [Required]
        public VehicleType VehicleType { get; set; }

        [Required(ErrorMessage = "Driver name is required")]
        [MaxLength(100)]
        public string DriverName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Mobile number is required")]
        [Phone]
        [MaxLength(15)]
        public string MobileNumber { get; set; } = string.Empty;
    }
}
