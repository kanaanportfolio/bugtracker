using BTA.Core.Models;

namespace BTA.Application.PluginInterfaces;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetTicketsAsync(string filter);
    Task<Ticket> GetTicketAsync(int id);
    Task<IEnumerable<Ticket>> GetTicketsByOwnerAsync(string Owner);
    Task<int> CreateTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(int id, Ticket ticket);
    Task DeleteTicketAsync(int id);
}
