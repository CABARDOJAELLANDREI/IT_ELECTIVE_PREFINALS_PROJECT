using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;
[Table("TicketTags")]
public class TicketTag
{
    [Required]
    public int TicketId { get; set; }

    [Required]
    public int TagId { get; set; }

    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;

    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; } = null!;
}