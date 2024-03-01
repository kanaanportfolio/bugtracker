using System.ComponentModel.DataAnnotations;
using BTA.Core.Models;

namespace BTA.Core.Validations;

public class Ticket_DueDateSetWhenOwnerHasValue : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;

        if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
        {
            if (!ticket.DueDate.HasValue)
            {
                return new ValidationResult("Due Date must be populated after Owner is.");
            }
        }
        return ValidationResult.Success;
    }
}
