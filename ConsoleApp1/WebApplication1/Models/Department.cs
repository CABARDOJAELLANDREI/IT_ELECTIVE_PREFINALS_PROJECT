using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public int IsActive { get; set; } = 1;

        // Navigation properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}