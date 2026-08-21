using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskApp.Models;

[Table("TicketAssignments")]
public class TicketAssignment
{
    [Required]
    public int TicketId { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public string AssignedAt { get; set; } = string.Empty;

    public string? UnassignedAt { get; set; }

    public bool IsPrimary { get; set; } = false;

    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;

    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; } = null!;
}