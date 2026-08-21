using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskApp.Models;

[Table("Tickets")]
public class Ticket
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int PriorityId { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string CreatedAt { get; set; } = string.Empty;

    [Required]
    public string UpdatedAt { get; set; } = string.Empty;

    public string? DueAt { get; set; }
    public string? ResolvedAt { get; set; }
    public string? ClosedAt { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public TicketCategory Category { get; set; } = null!;

    [ForeignKey(nameof(PriorityId))]
    public TicketPriority Priority { get; set; } = null!;

    [ForeignKey(nameof(StatusId))]
    public TicketStatus Status { get; set; } = null!;

    public ICollection<TicketAssignment> TicketAssignments { get; set; } = new List<TicketAssignment>();
    public ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
    public ICollection<TicketAttachment> TicketAttachments { get; set; } = new List<TicketAttachment>();
    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}