using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace App1.Models
{
    public class SalaryInfo
    {
        [Key] 
        public int Id { get; set; } 
        [Required]
        public decimal Net { get; set; }
        [Required]
        public decimal Gross { get; set; }

      [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
