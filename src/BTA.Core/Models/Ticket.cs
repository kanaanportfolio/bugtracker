using System.ComponentModel.DataAnnotations;
using BTA.Core.Validations;

namespace BTA.Core.Models;

public class Ticket
{
    public int? Id { get; set; }

    [Required] [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    [StringLength(25)]
    public string? Owner { get; set; } = string.Empty;

    [Required]
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    
    [Ticket_DueDateSetWhenOwnerHasValue]
    [Ticket_EnsureDueDateInFutureUponCreate]
    public DateTime? DueDate { get; set; }
    public DateTime? EnteredDate { get; set; }
}