using System.ComponentModel.DataAnnotations;

namespace App1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [MinLength(3)]
        public string Position { get; set; }
        public string Image { get; set; }
    }
}
