

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Company
    {
        [Key]
        [Column("Company Guid")]
        public Guid CompanyGuid { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Company name can't be longer than 30 characters")]
        public string? CompanyName { get; set; }

        public string? CompanyAddress { get; set; }

        public string? Country { get; set; }

       
    }
}
