using System.Reflection.Emit;
using BTA.Api.Filters;
using BTA.Api.QueryFilters;
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
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets([FromQuery] QueryFilter filter)
    {
        IQueryable<Ticket> tickets = _dbContext.Tickets;
        if (tickets == null)
        {
            return NotFound();
        }
        if (filter != null)
        {
            if (filter.TitleSearch != null)
            {
                tickets = tickets.Where(t => t.Title.Equals(filter.TitleSearch));
            }
            if (filter.DescriptionFilter != null)
            {
                tickets = tickets.Where(t => 
                    t.Description.Contains(filter.DescriptionFilter, StringComparison.OrdinalIgnoreCase));
            }
            if (filter.TitleFilter != null)
            {
                tickets = tickets.Where(t =>
                    t.Title.Contains(filter.TitleFilter, StringComparison.OrdinalIgnoreCase));
            }
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

    [HttpGet("owners/{owner}")]
    public ActionResult<IEnumerable<Ticket>> GetTicketsByOwner(string owner)
    {
        return Ok(_dbContext.Tickets.Where(t => t.Owner.Equals(owner)));
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