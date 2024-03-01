using BTA.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTA.Api.Filters;

public class Ticket_ValidateEnteredAndDueDateActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var ticket = context.ActionArguments["ticket"] as Ticket;

        var isValid = true;

        if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
        {
            if (!ticket.EnteredDate.HasValue)
            {
                context.ModelState.AddModelError(
                    "EnteredDate", "This action requires EnteredDate on Owner set.");
                isValid = false;
            }
            if (ticket.EnteredDate.HasValue && 
            ticket.EnteredDate.Value.Date > ticket.DueDate.Value.Date)
            {
                context.ModelState.AddModelError(
                    "DueDate", "DueDate must come after EnteredDate.");
                isValid = false;
            }
            if (!isValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
    }
}