using BTA.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTA.Api.Controllers;

[ApiController]
[Route("api/v2/projects")]
public class ProjectsController : ControllerBase
{
    private readonly BtaDbContext _dbContext;

    public ProjectsController(BtaDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
    {
        return Ok(await _dbContext.Projects.ToListAsync());
    }

    [HttpGet("{pid}")]
    public ActionResult<Project> GetProject(int pid)
    {
        var found = _dbContext.Projects.Find(pid);
        if (found == null)
        {
            return NotFound();
        }
        return Ok(found);
    }

    [HttpGet("{pid}/tickets")]
    public ActionResult<IEnumerable<Ticket>> GetProjectTickets(int pid, int tid)
    {
        var projectTickets = _dbContext.Tickets
                                       .Where(t => t.ProjectId == pid);
        if (!projectTickets.Any())
        {
            return NotFound();
        }
        return projectTickets.ToList();
    }

    [HttpGet("{pid}/tickets/{tid}")]
    public ActionResult<Ticket> GetProjectTicket(int pid, int tid)
    {
        var ticket = _dbContext.Tickets
                               .FirstOrDefault(t => t.ProjectId == pid && t.Id == tid);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Project newProject)
    {
        _dbContext.Add(newProject);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProject), new { pid = newProject.Id }, newProject);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Project updatedProject)
    {
        if (id != updatedProject.Id)
        {
            return BadRequest();
        }
        var found = _dbContext.Projects.Find(id);
        if (found == null)
        {
            return NotFound();
        }
        found.Name = updatedProject.Name;
        // _dbContext.Entry(updatedProject).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var project = _dbContext.Projects.Find(id);
        if (project == null)
        {
            return NotFound();
        }
        _dbContext.Entry(project).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}