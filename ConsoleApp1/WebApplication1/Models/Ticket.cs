using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Open"; // Open, In Progress, Closed

        [Required]
        [StringLength(50)]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High, Urgent

        [Required]
        public int CreatedByEmployeeId { get; set; }

        [ForeignKey("CreatedByEmployeeId")]
        public Employee? CreatedByEmployee { get; set; }

        [Required]
        public int IsActive { get; set; } = 1;

        // Navigation properties
        public ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
        public ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
    }
}