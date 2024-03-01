using BTA.Api.Filters;
using BTA.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTA.Api.Controllers;

[ApiController]
[Route("api/v2/tickets")]
[VersioningResourceFilter]
public class TicketsController : ControllerBase
{
    private readonly BtaDbContext _dbContext;
    public TicketsController(BtaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        var tickets = _dbContext.Tickets;
        if (tickets == null)
        {
            return NotFound();
        }
        return Ok(await tickets.ToListAsync());
    }


    [HttpGet]
    [Route("{id}")]
    public ActionResult<Ticket> GetTicket(int id)
    {
        var ticket = _dbContext.Tickets.Find(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPost]
    [Ticket_ExistingProjectId]
    [Ticket_ValidateEnteredAndDueDateActionFilter]
    public IActionResult CreateTicket(Ticket ticket)
    {
        _dbContext.Tickets.Add(ticket) ;
        _dbContext.SaveChanges();
        return CreatedAtAction(
            nameof(GetTicket),
            new { id = ticket.Id },
            ticket
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTicket(int id, Ticket ticket)
    {
        _dbContext.Entry(ticket).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTicket(int id)
    {
        return Ok("Deleting ticket");
    }
}