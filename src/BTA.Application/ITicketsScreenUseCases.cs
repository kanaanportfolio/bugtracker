using BTA.Core.Models;

namespace BTA.Application;

public interface ITicketsScreenUseCases
{
    Task<IEnumerable<Ticket>> ViewProjectTickets(int pid);
}