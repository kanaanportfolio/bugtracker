using System.Security.Cryptography;
using System.Reflection.Emit;
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

    public async Task<Ticket> ViewTicket(int id)
    {
        return await _ticketRepo.GetTicketAsync(id);
    }

    public async Task<IEnumerable<Ticket>> ViewOwnerTickets(string Owner)
    {
        return await _ticketRepo.GetTicketsByOwnerAsync(Owner);
    }

    public async Task EditTicket(int id, Ticket ticket)
    {
        await _ticketRepo.UpdateTicketAsync(id, ticket);
    }

    public async Task AddTicket(Ticket ticket)
    {
        await _ticketRepo.CreateTicketAsync(ticket);
    }
}