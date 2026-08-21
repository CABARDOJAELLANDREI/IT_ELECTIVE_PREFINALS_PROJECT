using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TicketAssignments")]
    public class TicketAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket? Ticket { get; set; }

        [Required]
        public int AssignedToEmployeeId { get; set; }

        [ForeignKey("AssignedToEmployeeId")]
        public Employee? AssignedToEmployee { get; set; }

        [Required]
        public int IsActive { get; set; } = 1;
    }
}