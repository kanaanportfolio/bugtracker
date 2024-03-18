using System.Dynamic;
using System.Reflection.Emit;
using BTA.Application.PluginInterfaces;
using BTA.Core.Models;
using BTA.Repository.ApiClient;

namespace BTA.Repository;


public class TicketRepository : ITicketRepository
{
    private readonly IWebApiExecuter executer;
    public TicketRepository(IWebApiExecuter Executer)
    {
        this.executer = Executer;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsAsync(string filter)
    {
        if (filter == null)
        {
            return await executer.InvokeGet<IEnumerable<Ticket>>("api/v2/tickets");
        }
        return await executer.InvokeGet<IEnumerable<Ticket>>($"api/v2/tickets{filter}");
    }
    public async Task<Ticket> GetTicketAsync(int id)
    {
        return await executer.InvokeGet<Ticket>($"api/v2/tickets/{id}");
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByOwnerAsync(string Owner)
    {
        return await executer.InvokeGet<IEnumerable<Ticket>>($"api/v2/tickets/owners/{Owner}");
    }

    public async Task<int> CreateTicketAsync(Ticket ticket)
    {
        var created = await executer.InvokePost<Ticket>("api/v2/tickets", ticket);
        return created.Id.Value;
    }
    public async Task UpdateTicketAsync(int id, Ticket ticket)
    {
        await executer.InvokePut<Ticket>($"api/v2/tickets/{id}", ticket);
    }
    public async Task DeleteTicketAsync(int id)
    {
        await executer.InvokeDelete($"api/v2/tickets/{id}");
    }
}