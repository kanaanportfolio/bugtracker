using BTA.Application.PluginInterfaces;
using BTA.Core.Models;

namespace BTA.Application;

public class TicketsScreenUseCases : ITicketsScreenUseCases
{
    private readonly IProjectRepository _projectRepo;

    public TicketsScreenUseCases(
        ITicketRepository TicketRepository,
        IProjectRepository ProjectRepository)
    {
        _projectRepo = ProjectRepository;
    }

    public async Task<IEnumerable<Ticket>> ViewProjectTickets(int pid)
    {
        return await _projectRepo.GetProjectTicketsAsync(pid);
    }
}