
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee
    {
        [Key]
        [Column("Employee Guid")]
        public Guid EmployeeGuid { get; set; }

        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Employee name can't be longer than 30 characters")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int EmployeeAge { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? EmployeePosition { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyGuid { get; set; }
        public Company Company { get; set; }


    }
}
