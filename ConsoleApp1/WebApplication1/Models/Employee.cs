using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

        [Required]
        public int IsActive { get; set; } = 1;

        // Navigation properties
        public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
        public ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
        public ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
    }
}