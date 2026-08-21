using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace WebApplication1.Models;

[Table("TicketAttachments")]
public class TicketAttachment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TicketId { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;

    [Required]
    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    [Required]
    public string UploadedAt { get; set; } = string.Empty;

    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;
}