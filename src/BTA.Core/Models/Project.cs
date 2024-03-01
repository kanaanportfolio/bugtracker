using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace BTA.Core.Models;

public class Project
{
    public int? Id { get; set; }
    
    [Required] [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    public List<Ticket>? Tickets { get; set; }
}