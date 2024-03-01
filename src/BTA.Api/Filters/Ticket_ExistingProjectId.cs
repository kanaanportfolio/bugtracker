using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BTA.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTA.Api.Filters;

public class Ticket_ExistingProjectId : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var ticket = context.ActionArguments["ticket"] as Ticket;

        var dbContext = context.HttpContext.RequestServices.GetRequiredService<BtaDbContext>();

        if (ticket.ProjectId != null)
        {
            var project = dbContext.Projects.Find(ticket.ProjectId);

            if (project == null)
            {
                context.ModelState.AddModelError("ticket", "Project for this ticket does not exist.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}