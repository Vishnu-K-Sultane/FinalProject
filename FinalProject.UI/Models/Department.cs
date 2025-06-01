using FinalProject.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI.Models
{
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }

        [Required, MaxLength(100)]
        public string DeptName { get; set; } = null!;

        [Required, MaxLength(100)]
        public string HODName { get; set; } = null!;
        [MaxLength(20)]
        public string? PhoneExtensionNo { get; set; }

        public ICollection<Employee>? EmpaneledDoctorNames { get; set; }
    }
}
