using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Required]
        public int IsActive { get; set; } = 1;

        // Navigation properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}