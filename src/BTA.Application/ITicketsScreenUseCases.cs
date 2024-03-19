using BTA.Core.Models;

namespace BTA.Application;

public interface ITicketsScreenUseCases
{
    Task<IEnumerable<Ticket>> ViewProjectTickets(int pid);
    Task<IEnumerable<Ticket>> ViewTicketsFiltered(string filter);
    Task<Ticket> ViewTicket(int id);
    Task<IEnumerable<Ticket>> ViewOwnerTickets(string Owner);
    Task EditTicket(int id, Ticket ticket);
    Task AddTicket(Ticket ticket);
}