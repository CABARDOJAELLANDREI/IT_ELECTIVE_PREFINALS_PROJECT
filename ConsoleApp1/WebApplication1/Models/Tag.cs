using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDeskApp.Models;

[Table("Tags")]
public class Tag
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
}