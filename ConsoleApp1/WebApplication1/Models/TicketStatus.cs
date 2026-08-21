using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskApp.Models;

[Table("TicketStatuses")]
public class TicketStatus
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public bool IsClosed { get; set; } = false;

    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}