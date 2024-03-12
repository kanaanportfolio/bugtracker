using BTA.Application.PluginInterfaces;
using BTA.Core.Models;

namespace BTA.Application;

public class TicketsScreenUseCases : ITicketsScreenUseCases
{
    private readonly IProjectRepository _projectRepo;
    private readonly ITicketRepository _ticketRepo;

    public TicketsScreenUseCases(
        ITicketRepository TicketRepository,
        IProjectRepository ProjectRepository)
    {
        _projectRepo = ProjectRepository;
        _ticketRepo = TicketRepository;
    }

    public async Task<IEnumerable<Ticket>> ViewProjectTickets(int pid)
    {
        return await _projectRepo.GetProjectTicketsAsync(pid);
    }

    public async Task<IEnumerable<Ticket>> ViewTicketsFiltered(string filter)
    {
        return await _ticketRepo.GetTicketsAsync(filter);
    }
}