using System.ComponentModel.DataAnnotations;
using BTA.Core.Models;

namespace BTA.Core.Validations;

public class Ticket_EnsureDueDateInFutureUponCreate : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;

        if (ticket != null && !ticket.Id.HasValue)
        {
            if (ticket.DueDate < DateTime.Now)
            {
                return new ValidationResult("Ticket DueDate must be in future upon Create.");
            }
        }
        return ValidationResult.Success;
    }
}
