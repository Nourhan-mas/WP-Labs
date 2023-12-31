using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace App1.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "ZipCode is required")]
        [Range(10000, 99999, ErrorMessage = "ZipCode must be a 5-digit number")]
        public int ZipCode { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }
        public List<Employee> Employees { get; set; } 
    }
}
